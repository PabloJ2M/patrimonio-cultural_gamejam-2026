using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    
    [Header("Detection")]
    [SerializeField, Min(1f)] private float maxDistance;
    [SerializeField, Min(0)] private float radius;
    [SerializeField] private LayerMask interactableLayer;
    
    private Transform _cameraTransform;
    private IInteractable _currentInteraction;
    private bool _isPressed;

    private void Awake() => _cameraTransform = Camera.main?.transform;
    private void OnEnable() => inputAction.action.performed += OnInputPerformed;
    private void OnDisable() => inputAction.action.performed -= OnInputPerformed;

    private void OnInputPerformed(InputAction.CallbackContext ctx)
    {
        _isPressed = ctx.action.IsPressed();
        _currentInteraction?.Select(_isPressed);
        _currentInteraction?.UnHightlighted();
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!_cameraTransform) return;
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_cameraTransform.position, maxDistance * _cameraTransform.forward);
        Gizmos.DrawSphere(_cameraTransform.position + _cameraTransform.forward * maxDistance, radius);
    }
    #endif

    private void Update()
    {
        Physics.SphereCast(_cameraTransform.position, 0.2f, _cameraTransform.forward, out var hit, maxDistance, interactableLayer);
        OnUpdateCast(hit.collider);
    }
    private void OnUpdateCast(Collider hitCollider)
    {
        if (_isPressed) return;
        
        if (!hitCollider) {
            UnHighlight();
            return;
        }

        if (hitCollider.TryGetComponent(out IInteractable interactable))
            Highlight(interactable);
    }
    
    private void UnHighlight()
    {
        _currentInteraction?.UnHightlighted();
        _currentInteraction = null;
    }
    private void Highlight(IInteractable newInteractable)
    {
        if (_currentInteraction == newInteractable) return;
        
        _currentInteraction = newInteractable;
        _currentInteraction?.Highlighted();
    }
}