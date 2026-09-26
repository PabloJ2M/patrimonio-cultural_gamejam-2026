namespace UnityEngine.InputSystem
{
    using EventSystems;
    
    public abstract class PointerBehaviour : ActionBase, IPointerEnterHandler, IPointerExitHandler
    {
        protected bool IsOverElement;
        
        protected virtual void Start() => Actions.UI.Point.performed += OnPointerUpdate;
        protected virtual void OnDestroy() => Actions.UI.Point.performed -= OnPointerUpdate;

        protected abstract void OnPointerUpdate(InputAction.CallbackContext ctx);
        
        public void OnPointerEnter(PointerEventData eventData) => IsOverElement = true;
        public void OnPointerExit(PointerEventData eventData) => IsOverElement = false;
    }
}