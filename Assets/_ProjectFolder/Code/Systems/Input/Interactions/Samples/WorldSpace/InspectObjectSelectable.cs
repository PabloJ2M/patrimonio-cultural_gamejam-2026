namespace UnityEngine.InputSystem.Samples
{
    public class InspectObjectSelectable : TouchBehaviour
    {
        public Vector3 OriginPosition { get; private set; }
        public Quaternion OriginRotation { get; private set; }

        private Rigidbody _rigidbody;
        private bool _isViewed;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
        }
        protected override void OnPointerUpdate(InputAction.CallbackContext ctx) { }

        protected override void OnSelect()
        {
            if (_isViewed) return;
            
            OriginPosition = transform.position;
            OriginRotation = transform.rotation;
            _isViewed = InspectObjectPoint.Instance.SelectObject(this);
            
            if (_isViewed)
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        protected override void OnDeselect() { }

        public override void ForceDisable()
        {
            base.ForceDisable();
            _isViewed = false;
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}