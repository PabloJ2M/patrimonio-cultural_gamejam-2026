namespace UnityEngine.InputSystem
{
    using EventSystems;
    
    public abstract class TouchBehaviour : PointerBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected bool IsSelected;
        
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            IsSelected = true;
            OnSelect();
        }
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            IsSelected = false;
            OnDeselect();
        }

        protected abstract void OnSelect();
        protected abstract void OnDeselect();

        public virtual void ForceDisable() => IsSelected = false;
    }
}