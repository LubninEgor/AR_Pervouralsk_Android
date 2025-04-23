using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class MagnetScroll : MonoBehaviour
{
    [Header("Magnet Settings")]
    public float magnetStrength = 10f;    // Сила притяжения
    public float magnetZone = 0.2f;       // Зона действия магнита

    private ScrollRect scrollRect;
    private bool isDragging = false;
    private float[] elementPositions;
    private int magnetElementIndex;       // Теперь индекс определяется автоматически

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
        
        // Рассчитываем позиции элементов (0-1)
        for (int i = 0; i < childCount; i++)
        {
            elementPositions[i] = (float)i / (childCount - 1);
        }
    }

    void Update()
    {
        UpdateMagnetElementIndex();
        
        if (!isDragging)
        {
            ApplyMagnetEffect();
        }
    }

    // Автоматически определяем ближайший элемент
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

        // Если в зоне магнита
        if (distance < magnetZone)
        {
            // Плавное притяжение
            float newPos = Mathf.Lerp(
                currentPos, 
                magnetPos, 
                magnetStrength * Time.deltaTime * (1 - distance/magnetZone)
            );
            scrollRect.horizontalNormalizedPosition = newPos;
        }
    }

    public void OnBeginDrag()
    {
        isDragging = true;
    }

    public void OnEndDrag()
    {
        isDragging = false;
    }
}