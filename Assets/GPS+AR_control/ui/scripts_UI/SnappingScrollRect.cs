using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class MagnetScroll : MonoBehaviour
{
    [Header("Magnet Settings")]
    public int magnetElementIndex = 1; // Индекс элемента с магнитом (1 - второй элемент)
    public float magnetStrength = 2f; // Сила притяжения
    public float magnetZone = 0.3f; // Зона действия магнита

    private ScrollRect scrollRect;
    private bool isDragging = false;
    private float[] elementPositions;
    private float contentWidth;

    void Start()
    {
		
        scrollRect = GetComponent<ScrollRect>();
        CalculateElementPositions();
		scrollRect.horizontalNormalizedPosition = elementPositions[0];
		
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
        if (!isDragging)
        {
            ApplyMagnetEffect();
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
            float newPos = Mathf.Lerp(currentPos, magnetPos, magnetStrength * Time.deltaTime * (1 - distance/magnetZone));
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