using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMouseLook : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    
    private InputAction rotateAction;
    private PlayerControls inputActions;

    private void Awake()
    {
        // Инициализация Input System
        inputActions = new PlayerControls();
        rotateAction = inputActions.Player.Rotate;
    }

    private void OnEnable()
    {
        rotateAction.Enable();
        rotateAction.performed += HandleRotation;
    }

    private void OnDisable()
    {
        rotateAction.Disable();
        rotateAction.performed -= HandleRotation;
    }

    private void HandleRotation(InputAction.CallbackContext context)
    {
        Vector2 delta = context.ReadValue<Vector2>();
        transform.Rotate(
            delta.y * rotationSpeed * Time.deltaTime,
            -delta.x * rotationSpeed * Time.deltaTime,
            0,
            Space.World
        );
    }
}