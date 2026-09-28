namespace UnityEngine.InputSystem.Samples
{
    using EventSystems;
    
    public class InspectObjectSelectable : TouchBehaviour
    {
        [SerializeField] private Selectable3D selectable;
        
        public Vector3 OriginPosition { get; private set; }
        public Quaternion OriginRotation { get; private set; }

        private Rigidbody _rigidbody;
        private bool _isViewed;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        protected override void Start()
        {
            base.Start();
            OriginPosition = transform.position;
            OriginRotation = transform.rotation;
        }
        
        protected override void OnPointerUpdate(InputAction.CallbackContext ctx) { }

        protected override void OnSelect()
        {
            if (_isViewed) return;
            _isViewed = InspectObjectPoint.Instance.SelectObject(this);

            if (!_isViewed) return;
            
            selectable?.SetInteractable(false);
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        protected override void OnDeselect() { }

        public override void ForceDisable()
        {
            base.ForceDisable();
            
            _isViewed = false;
            _rigidbody.constraints = RigidbodyConstraints.None;
            selectable?.SetInteractable(true);
        }
    }
}