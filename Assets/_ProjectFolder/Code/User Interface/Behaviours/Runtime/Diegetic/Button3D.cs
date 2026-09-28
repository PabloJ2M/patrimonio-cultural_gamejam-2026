namespace UnityEngine.EventSystems
{
    using Events;
    
    public class Button3D : Selectable3D
    {
        [SerializeField] private bool interactable = true;
        [SerializeField] private UnityEvent onClick;
        
        public UnityEvent OnClick => onClick;

        public void SetInteractable(bool value)
        {
            interactable = value;
            SetColor(interactable ? colors.normalColor : colors.disabledColor);
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable) return;
            
            base.OnPointerClick(eventData);
            onClick.Invoke();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (interactable)
                base.OnPointerEnter(eventData);
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            if (interactable)
                base.OnPointerExit(eventData);
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (interactable)
                base.OnPointerUp(eventData);
        }
    }
}