using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScaler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private RectTransform targetTransform;

    [Header("Scale Settings")]
    [SerializeField] private float scaleSpeed = 1f;
    [SerializeField] private Vector2 scaleStep = new Vector2(0.2f, 0.2f);
    [SerializeField] private Vector2 minScale = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 maxScale = new Vector2(2f, 2f);

    private Coroutine scalingCoroutine;
    private Vector3 originalScale;

    private void Start()
    {
        if (targetTransform == null)
            targetTransform = GetComponent<RectTransform>();
            
        originalScale = targetTransform.localScale;
    }

    // Уменьшение размера
    public void ScaleDown()
    {
        Vector3 newScale = new Vector3(
            Mathf.Clamp(targetTransform.localScale.x - scaleStep.x, minScale.x, maxScale.x),
            Mathf.Clamp(targetTransform.localScale.y - scaleStep.y, minScale.y, maxScale.y),
            originalScale.z
        );
        StartScaling(newScale);
    }

    // Увеличение размера
    public void ScaleUp()
    {
        Vector3 newScale = new Vector3(
            Mathf.Clamp(targetTransform.localScale.x + scaleStep.x, minScale.x, maxScale.x),
            Mathf.Clamp(targetTransform.localScale.y + scaleStep.y, minScale.y, maxScale.y),
            originalScale.z
        );
        StartScaling(newScale);
    }

    private void StartScaling(Vector3 targetScale)
    {
        if (scalingCoroutine != null)
            StopCoroutine(scalingCoroutine);
        
        scalingCoroutine = StartCoroutine(SmoothScale(targetScale));
    }

    private IEnumerator SmoothScale(Vector3 targetScale)
    {
        Vector3 startScale = targetTransform.localScale;
        float progress = 0;

        while (progress < 1)
        {
            progress += Time.deltaTime * scaleSpeed;
            targetTransform.localScale = Vector3.Lerp(startScale, targetScale, progress);
            yield return null;
        }

        targetTransform.localScale = targetScale;
        scalingCoroutine = null;
    }

    // Сброс к исходному размеру
    public void ResetSize()
    {
        targetTransform.localScale = originalScale;
    }
}