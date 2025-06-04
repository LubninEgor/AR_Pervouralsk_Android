using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Добавляем для работы с корутинами

[RequireComponent(typeof(ScrollRect))]
public class MagnetScroll : MonoBehaviour
{
    [Header("Magnet Settings")]
    public float magnetStrength = 10f;
    public float magnetZone = 0.2f;
    public float scrollDelay = 1f; // Добавляем параметр задержки

    private ScrollRect scrollRect;
    private bool isDragging = false;
    private float[] elementPositions;
    private int magnetElementIndex;
    private bool isAutoScrolling = false;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CalculateElementPositions();
        scrollRect.horizontalNormalizedPosition = elementPositions[magnetElementIndex];
    }

    void CalculateElementPositions()
    {
        int childCount = scrollRect.content.childCount;
        elementPositions = new float[childCount];
        
        for (int i = 0; i < childCount; i++)
        {
            elementPositions[i] = (float)i / (childCount - 1);
        }
    }

    void Update()
    {
        if (!isAutoScrolling)
        {
            UpdateMagnetElementIndex();
        }
        
        if (!isDragging)
        {
            ApplyMagnetEffect();
        }
    }

    void UpdateMagnetElementIndex()
    {
        float currentPos = scrollRect.horizontalNormalizedPosition;
        float minDistance = Mathf.Infinity;
        
        for (int i = 0; i < elementPositions.Length; i++)
        {
            float distance = Mathf.Abs(currentPos - elementPositions[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                magnetElementIndex = i;
            }
        }
    }

    void ApplyMagnetEffect()
    {
        float currentPos = scrollRect.horizontalNormalizedPosition;
        float magnetPos = elementPositions[magnetElementIndex];
        float distance = Mathf.Abs(currentPos - magnetPos);

        if (distance < magnetZone || isAutoScrolling)
        {
            float newPos = Mathf.Lerp(
                currentPos, 
                magnetPos, 
                magnetStrength * Time.deltaTime
            );
            scrollRect.horizontalNormalizedPosition = newPos;
            
            if (Mathf.Abs(newPos - magnetPos) < 0.001f)
            {
                isAutoScrolling = false;
            }
        }
    }

    public void OnBeginDrag()
    {
        isDragging = true;
        isAutoScrolling = false;
    }

    public void OnEndDrag()
    {
        isDragging = false;
        isAutoScrolling = true;
    }
    
    // Изменяем метод для добавления задержки
    public void ScrollToNext()
    {
        if (magnetElementIndex < elementPositions.Length - 1)
        {
            StartCoroutine(ScrollToNextWithDelay());
        }
    }

    // Добавляем корутину для задержки
    private IEnumerator ScrollToNextWithDelay()
    {
        // Ждем указанное количество секунд
        yield return new WaitForSeconds(scrollDelay);
        
        magnetElementIndex++;
        isAutoScrolling = true;
        Debug.Log("Scrolling to index: " + magnetElementIndex);
    }
}