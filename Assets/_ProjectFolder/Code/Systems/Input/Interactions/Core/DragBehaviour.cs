namespace UnityEngine.InputSystem
{
    public abstract class DragBehaviour : TouchBehaviour
    {
        protected Vector2 PointerPosition;
        protected bool IsDragging;

        protected override void OnPointerUpdate(InputAction.CallbackContext ctx)
        {
            if (!IsDragging) return;
            
            PointerPosition = ctx.ReadValue<Vector2>();
            OnUpdateSelection(PointerPosition);
        }
        
        protected void ForceUpdate() => OnUpdateSelection(Actions.UI.Point.ReadValue<Vector2>());
        protected abstract void OnUpdateSelection(Vector2 screenPosition);
        
        protected override void OnSelect() => IsDragging = true;
        protected override void OnDeselect()
        {
            IsDragging = false;
            PointerPosition = Vector2.zero;
        }
    }
}
