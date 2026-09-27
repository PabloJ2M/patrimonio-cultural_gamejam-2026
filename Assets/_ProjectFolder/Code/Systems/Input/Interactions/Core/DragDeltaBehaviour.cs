namespace UnityEngine.InputSystem
{
    public abstract class DragDeltaBehaviour : DragBehaviour
    {
        private Vector2 _lastScreenPosition;
        
        protected override void OnUpdateSelection(Vector2 screenPosition)
        {
            if (_lastScreenPosition == Vector2.zero)
                _lastScreenPosition = PointerPosition;
            
            var delta = _lastScreenPosition - screenPosition;
            _lastScreenPosition = screenPosition;
            OnUpdateDelta(delta);
        }
        protected override void OnDeselect()
        {
            base.OnDeselect();
            _lastScreenPosition = Vector2.zero;
        }

        protected abstract void OnUpdateDelta(Vector2 delta);
    }
}