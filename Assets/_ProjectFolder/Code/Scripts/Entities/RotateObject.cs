using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : InteractableBehaviour
{
    [SerializeField] private InputActionReference inputDelta;
    [SerializeField, Min(0.1f)] private float speedMultiplier = 1f;
    [SerializeField] private Vector3 axis;
    
    public override void Select(bool isPressed)
    {
        base.Select(isPressed);
        
        if (isPressed) inputDelta.action.performed += OnUpdate;
        else inputDelta.action.performed -= OnUpdate;
    }

    private void Rotate(float delta) => transform.Rotate(axis, delta);
    private void OnUpdate(InputAction.CallbackContext ctx)
    {
        if (IsSelected)
            Rotate(ctx.ReadValue<Vector2>().x);
    }
}