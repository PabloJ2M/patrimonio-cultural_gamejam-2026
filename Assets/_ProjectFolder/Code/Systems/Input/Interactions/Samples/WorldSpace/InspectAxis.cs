namespace UnityEngine.InputSystem.Samples
{
    public class InspectAxis : DragDeltaBehaviour
    {
        [SerializeField] private Vector3 axis;
        [SerializeField, Min(0f)] private float sensitivity = 1f;
        
        private Quaternion _targetRotation;

        protected override void Start()
        {
            base.Start();
            _targetRotation = transform.rotation;
        }
        
        protected override void OnUpdateDelta(Vector2 delta)
        {
            var deltaRotationX = Quaternion.AngleAxis(delta.y * sensitivity, transform.right);
            var deltaRotationY = Quaternion.AngleAxis(delta.x * sensitivity, transform.up);
            var deltaRotationZ = Quaternion.identity;

            var deltaRotation = Quaternion.identity;

            if (axis.y != 0) deltaRotation *= deltaRotationY;
            if (axis.x != 0) deltaRotation *= deltaRotationX;
            if (axis.z != 0) deltaRotation *= deltaRotationZ;
            
            _targetRotation *= deltaRotation;
            transform.rotation = _targetRotation;
        }
    }
}