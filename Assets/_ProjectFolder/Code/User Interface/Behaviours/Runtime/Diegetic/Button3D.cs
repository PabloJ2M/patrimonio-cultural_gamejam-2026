namespace UnityEngine.EventSystems
{
    using Events;
    
    public class Button3D : Selectable3D
    {
        [SerializeField] private UnityEvent onClick;
        
        public UnityEvent OnClick => onClick;
        
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            if (isInteractable)
                onClick.Invoke();
        }
    }
}