namespace UnityEngine.InputSystem.Samples
{
    public class InspectAxis : DragDeltaBehaviour
    {
        [SerializeField] private Vector3 axis;
        [SerializeField, Min(0.1f)] private float sensitivity = 1f, smoothing = 1f;
        [SerializeField] private bool useLocalAxis = false;
        
        [SerializeField] private Vector3 rotationLimitMin = new Vector3(-90, -180, 0);
        [SerializeField] private Vector3 rotationLimitMax = new Vector3(90, 180, 0);
        
        private Vector3 _targetRotation;
        private Vector3 _currentRotation = Vector3.zero;

        private void Update()
        {
            if (!IsDragging) return;
            
            _currentRotation = Vector3.Lerp(_currentRotation, _targetRotation, smoothing);
            
            _currentRotation.x = Mathf.Clamp(_currentRotation.x, rotationLimitMin.x, rotationLimitMax.x);
            _currentRotation.y = Mathf.Clamp(_currentRotation.y, rotationLimitMin.y, rotationLimitMax.y);
            _currentRotation.z = Mathf.Clamp(_currentRotation.z, rotationLimitMin.z, rotationLimitMax.z);
            
            transform.localRotation = Quaternion.Euler(_currentRotation);
        }
        
        protected override void OnUpdateDelta(Vector2 delta)
        {
            var mouseDelta = new Vector3(-delta.y * axis.x * sensitivity,
                delta.x * axis.y * sensitivity,
                0f * axis.z * sensitivity
            );

            _targetRotation += mouseDelta;
        }
    }
}