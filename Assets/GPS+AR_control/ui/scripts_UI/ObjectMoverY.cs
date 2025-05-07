using UnityEngine;

public class ObjectMoverY : MonoBehaviour
{
    [Header("Position Settings")]
    [SerializeField] private float _topPosition = 225f;
    [SerializeField] private float _bottomPosition = -225f;
    [SerializeField] private float _moveDuration = 0.5f;

    [Header("Current State")]
    [SerializeField] private bool _isAtTop = true;

    private RectTransform _rectTransform;
    private float _moveProgress;
    private bool _isMoving;
    private float _startX;
    private float _targetX;

    private void Awake()
    {
        // Получаем RectTransform (работает для UI элементов)
        _rectTransform = GetComponent<RectTransform>();
        
        // Устанавливаем начальную позицию
        SetInitialPosition();
    }

    private void SetInitialPosition()
    {
        Vector2 currentPos = _rectTransform.anchoredPosition;
        currentPos.x = _isAtTop ? _topPosition : _bottomPosition;
        _rectTransform.anchoredPosition = currentPos;
    }

    private void Update()
    {
        if (_isMoving)
        {
            // Обновляем прогресс анимации
            _moveProgress += Time.deltaTime / _moveDuration;
            
            // Вычисляем новую позицию Y
            float newX = Mathf.Lerp(_startX, _targetX, SmoothStep(_moveProgress));
            
            // Применяем новую позицию
            Vector2 currentPos = _rectTransform.anchoredPosition;
            currentPos.x = newX;
            _rectTransform.anchoredPosition = currentPos;
            
            // Проверяем завершение анимации
            if (_moveProgress >= 1f)
            {
                _isMoving = false;
                currentPos.x = _targetX;
                _rectTransform.anchoredPosition = currentPos;
            }
        }
    }

    // Метод для перемещения вверх (назначьте на первую кнопку)
    public void MoveToTop()
    {
        if (!_isAtTop && !_isMoving)
        {
            StartMovement(_topPosition);
            _isAtTop = true;
        }
    }

    // Метод для перемещения вниз (назначьте на вторую кнопку)
    public void MoveToBottom()
    {
        if (_isAtTop && !_isMoving)
        {
            StartMovement(_bottomPosition);
            _isAtTop = false;
        }
    }

    private void StartMovement(float targetX)
    {
        _startX = _rectTransform.anchoredPosition.x;
        _targetX = targetX;
        _moveProgress = 0f;
        _isMoving = true;
    }

    // Функция плавности (smoothstep)
    private float SmoothStep(float t)
    {
        return t * t * (3f - 2f * t);
    }
}