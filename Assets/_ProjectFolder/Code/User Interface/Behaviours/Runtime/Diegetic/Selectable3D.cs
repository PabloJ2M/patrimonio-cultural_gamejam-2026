namespace UnityEngine.EventSystems
{
    using UI;

    public abstract class Selectable3D : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Renderer render;
        [SerializeField] protected ColorBlock colors;

        protected static readonly int ColorID = Shader.PropertyToID("_Color");
        protected MaterialPropertyBlock _propertyBlock;
        protected Color _defaultColor;

        protected virtual void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _defaultColor = render.sharedMaterial.GetColor(ColorID);
        }
        protected virtual void Reset() => render = GetComponent<Renderer>();

        public virtual void OnPointerClick(PointerEventData eventData) => SetColor(colors.pressedColor);
        public virtual void OnPointerUp(PointerEventData eventData) => SetColor(colors.selectedColor);
        public virtual void OnPointerEnter(PointerEventData eventData) => SetColor(colors.highlightedColor);
        public virtual void OnPointerExit(PointerEventData eventData) => SetColor(colors.normalColor);

        private void SetColor(Color color)
        {
            _propertyBlock.SetColor(ColorID, _defaultColor * color);
            render.SetPropertyBlock(_propertyBlock);
        }
    }
}