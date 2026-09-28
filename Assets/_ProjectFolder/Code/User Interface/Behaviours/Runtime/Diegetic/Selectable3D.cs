namespace UnityEngine.EventSystems
{
    using UI;

    public class Selectable3D : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected bool isInteractable = true;
        [SerializeField] protected Renderer render;
        [SerializeField] protected ColorBlock colors;

        private static readonly int ColorID = Shader.PropertyToID("_BaseColor");
        private MaterialPropertyBlock _propertyBlock;
        private Color _defaultColor;

        protected virtual void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _defaultColor = render.sharedMaterial.GetColor(ColorID);
        }
        protected virtual void Reset() => render = GetComponent<Renderer>();

        public virtual void SetInteractable(bool value)
        {
            SetColor(value ? colors.normalColor : colors.disabledColor);
            isInteractable = value;
        }

        public virtual void OnPointerClick(PointerEventData eventData) => SetColor(colors.pressedColor);
        public virtual void OnPointerUp(PointerEventData eventData) => SetColor(colors.selectedColor);
        public virtual void OnPointerEnter(PointerEventData eventData) => SetColor(colors.highlightedColor);
        public virtual void OnPointerExit(PointerEventData eventData) => SetColor(colors.normalColor);

        protected void SetColor(Color color)
        {
            if (!isInteractable) return;
            
            _propertyBlock?.SetColor(ColorID, _defaultColor * color);
            render?.SetPropertyBlock(_propertyBlock);
        }
    }
}