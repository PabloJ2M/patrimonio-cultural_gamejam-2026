namespace UnityEngine.EventSystems
{
    using UI;
    using Events;
    
    public class Button3D : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Renderer render;
        [SerializeField] private ColorBlock colors;
        
        [SerializeField] private UnityEvent onClick;
        
        public UnityEvent OnClick => onClick;

        private static readonly int ColorID = Shader.PropertyToID("_Color");
        private MaterialPropertyBlock _propertyBlock;
        private Color _defaultColor;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _defaultColor = render.sharedMaterial.GetColor(ColorID);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SetColor(colors.pressedColor);
            onClick.Invoke();
        }
        public void OnPointerUp(PointerEventData eventData) => SetColor(colors.selectedColor);
        public void OnPointerEnter(PointerEventData eventData) => SetColor(colors.highlightedColor);
        public void OnPointerExit(PointerEventData eventData) => SetColor(colors.normalColor);

        private void SetColor(Color color)
        {
            _propertyBlock.SetColor(ColorID, _defaultColor * color);
            render.SetPropertyBlock(_propertyBlock);
        }
    }
}