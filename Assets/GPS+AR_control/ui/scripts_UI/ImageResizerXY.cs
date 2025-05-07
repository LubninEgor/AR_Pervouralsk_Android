using UnityEngine;
using UnityEngine.UI;

public class ImageResizerXY : MonoBehaviour
{
    [Header("Image Reference")]
    [Tooltip("Перетащите сюда ваш Image компонент")]
    public Image targetImage;

    [Header("Size Settings")]
    [SerializeField] private float _minHeight = 333f;
    [SerializeField] private float _maxHeight = 860f;
    [SerializeField] private float _minWidth = 200f;
    [SerializeField] private float _maxWidth = 500f;
    [SerializeField] private float _animationDuration = 0.3f;

    [Header("Current State")]
    [Tooltip("Текущее состояние размера (только для просмотра)")]
    [SerializeField] private bool _isExpanded = false;

    private RectTransform _rectTransform;
    private float _animationProgress;
    private bool _isAnimating;
    private Vector2 _startSize;
    private Vector2 _targetSize;

    private void Awake()
    {
        _rectTransform = targetImage.GetComponent<RectTransform>();
        SetInitialSize();
    }

    private void SetInitialSize()
    {
        Vector2 newSize = new Vector2(
            _isExpanded ? _maxWidth : _minWidth,
            _isExpanded ? _maxHeight : _minHeight
        );
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y);
    }

    private void Update()
    {
        if (_isAnimating)
        {
            _animationProgress += Time.deltaTime / _animationDuration;
            
            Vector2 newSize = new Vector2(
                Mathf.Lerp(_startSize.x, _targetSize.x, EaseInOut(_animationProgress)),
                Mathf.Lerp(_startSize.y, _targetSize.y, EaseInOut(_animationProgress))
            );
            
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y);
            
            if (_animationProgress >= 1f)
            {
                _isAnimating = false;
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _targetSize.x);
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _targetSize.y);
            }
        }
    }

    public void ToggleImageSize()
    {
        _isExpanded = !_isExpanded;
        
        _startSize = new Vector2(
            _rectTransform.rect.width,
            _rectTransform.rect.height
        );
        
        _targetSize = new Vector2(
            _isExpanded ? _maxWidth : _minWidth,
            _isExpanded ? _maxHeight : _minHeight
        );
        
        _animationProgress = 0f;
        _isAnimating = true;
    }

    private float EaseInOut(float t)
    {
        return t < 0.5f 
            ? 2f * t * t 
            : 1f - Mathf.Pow(-2f * t + 2f, 2f) / 2f;
    }

    public void SetImageSize(bool expand)
    {
        if (_isExpanded != expand)
        {
            ToggleImageSize();
        }
    }
}