using UnityEngine;
using UnityEngine.UI;

public class ImageResizer : MonoBehaviour
{
    [Header("Image Reference")]
    [Tooltip("Перетащите сюда ваш Image компонент")]
    public Image targetImage;

    [Header("Size Settings")]
    [SerializeField] private float _minHeight = 333f;
    [SerializeField] private float _maxHeight = 860f;
    [SerializeField] private float _animationDuration = 0.3f;

    [Header("Current State")]
    [Tooltip("Текущее состояние размера (только для просмотра)")]
    [SerializeField] private bool _isExpanded = false;

    private RectTransform _rectTransform;
    private float _animationProgress;
    private bool _isAnimating;
    private float _startHeight;
    private float _targetHeight;

    private void Awake()
    {
        // Получаем RectTransform изображения
        _rectTransform = targetImage.GetComponent<RectTransform>();
        
        // Устанавливаем начальный размер
        SetInitialSize();
    }

    private void SetInitialSize()
    {
        _rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Vertical, 
            _isExpanded ? _maxHeight : _minHeight
        );
    }

    private void Update()
    {
        if (_isAnimating)
        {
            // Обновляем прогресс анимации
            _animationProgress += Time.deltaTime / _animationDuration;
            
            // Вычисляем новую высоту
            float newHeight = Mathf.Lerp(_startHeight, _targetHeight, EaseInOut(_animationProgress));
            
            // Применяем новую высоту
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
            
            // Проверяем завершение анимации
            if (_animationProgress >= 1f)
            {
                _isAnimating = false;
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _targetHeight);
            }
        }
    }

    // Метод для вызова из кнопки (назначьте в инспекторе)
    public void ToggleImageSize()
    {
        // Переключаем состояние
        _isExpanded = !_isExpanded;
        
        // Настраиваем параметры анимации
        _startHeight = _rectTransform.rect.height;
        _targetHeight = _isExpanded ? _maxHeight : _minHeight;
        _animationProgress = 0f;
        _isAnimating = true;
    }

    // Функция плавности (ease-in-out)
    private float EaseInOut(float t)
    {
        return t < 0.5f 
            ? 2f * t * t 
            : 1f - Mathf.Pow(-2f * t + 2f, 2f) / 2f;
    }

    // Дополнительный метод для принудительной установки размера
    public void SetImageSize(bool expand)
    {
        if (_isExpanded != expand)
        {
            ToggleImageSize();
        }
    }
}