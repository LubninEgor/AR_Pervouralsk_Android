using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Android;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GeoLocationAR : MonoBehaviour
{
    [System.Serializable]
    public class ARTarget
    {
        public GameObject prefab;    // Префаб для отображения AR-объекта
        public double latitude;      // Целевая широта
        public double longitude;     // Целевая долгота
        public float targetDistance; // Дистанция, на которой будет отображаться объект (в метрах)
        [HideInInspector] public GameObject instance; // Ссылка на созданный объект
    }

    public ARSessionOrigin arSessionOrigin;
    public List<ARTarget> targets = new List<ARTarget>();
	public TextMeshProUGUI gpsText; // UI Text для отображения GPS данных

    private bool gpsInitialized = false;
    private bool compassInitialized = false;
    private float initialHeading = 0f; // Угол на север, сохраненный при запуске
    private bool headingCaptured = false; // Флаг для захвата угла

    private float smoothedHeading = 0f; // Сглаженный угол поворота
    private float smoothingSpeed = 2f; // Скорость сглаживания

    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            StartCoroutine(InitializeGPS());
        }
        else
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        // Инициализация компаса
        if (SystemInfo.supportsGyroscope || SystemInfo.supportsAccelerometer)
        {
            Input.compass.enabled = true;
            compassInitialized = true;
        }
        else
        {
            Debug.LogWarning("Компас не поддерживается на этом устройстве.");
        }
    }

    IEnumerator InitializeGPS()
    {
        Input.location.Start(1f, 1f);
        while (Input.location.status == LocationServiceStatus.Initializing && Time.time < 20)
        {
            yield return null;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Не удалось получить координаты GPS.");
        }
        else
        {
            gpsInitialized = true;
            Debug.Log($"GPS начался. Текущая позиция: {Input.location.lastData.latitude}, {Input.location.lastData.longitude}");
        }
    }

    void Update()
    {
        if (gpsInitialized)
        {
            if (gpsText != null)
            {
                gpsText.text = $"Latitude: {Input.location.lastData.latitude:F6}\nLongitude: {Input.location.lastData.longitude:F6}";
            }

            if (compassInitialized && !headingCaptured)
            {
                // Сохраняем начальный угол компаса
                initialHeading = Input.compass.trueHeading;
                headingCaptured = true;
            }

            if (headingCaptured)
            {
                // Обновляем сглаженный угол
                smoothedHeading = Mathf.LerpAngle(smoothedHeading, initialHeading, Time.deltaTime * smoothingSpeed);
            }

            foreach (var target in targets)
            {
                float distance = CalculateDistanceToTarget(Input.location.lastData.latitude, Input.location.lastData.longitude, target.latitude, target.longitude);

                if (distance <= target.targetDistance)
                {
                    CreateOrUpdateARObject(target);
                }
                else
                {
                    if (target.instance != null)
                    {
                        Destroy(target.instance);
                        target.instance = null;
                    }
                }
            }
        }
    }

    void CreateOrUpdateARObject(ARTarget target)
    {
        Vector3 targetPosition = GetARPositionFromGPS(target.latitude, target.longitude);

        if (target.instance == null)
        {
            target.instance = Instantiate(target.prefab, targetPosition, GetNorthAlignedRotation());
        }
        else
        {
            target.instance.transform.position = targetPosition;
            target.instance.transform.rotation = GetNorthAlignedRotation();
        }
    }

    Quaternion GetNorthAlignedRotation()
    {
        return Quaternion.Euler(0, -smoothedHeading, 0);
    }

    float CalculateDistanceToTarget(double lat1, double lon1, double lat2, double lon2)
    {
        float R = 6371f; // Радиус Земли в километрах
        float dLat = (float)(lat2 - lat1) * Mathf.Deg2Rad;
        float dLon = (float)(lon2 - lon1) * Mathf.Deg2Rad;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + Mathf.Cos((float)(lat1) * Mathf.Deg2Rad) * Mathf.Cos((float)(lat2) * Mathf.Deg2Rad) * Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000f; // Возвращаем расстояние в метрах
    }

    Vector3 GetARPositionFromGPS(double latitude, double longitude)
    {
        float x = (float)(longitude - Input.location.lastData.longitude) * 100000f;
        float z = (float)(latitude - Input.location.lastData.latitude) * 100000f;
        return new Vector3(x, 0f, z);
    }
}
