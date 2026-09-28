using System.Collections;

namespace UnityEngine.InputSystem.Samples
{
    using Events;

    public class InspectObjectPoint : MonoBehaviour
    {
        [SerializeField] private Transform point;
        [SerializeField] private float speed;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private UnityEvent<bool> onStatusChanged;

        public static InspectObjectPoint Instance;
        
        private InspectObjectSelectable _current;
        private float _target;
        
        private Vector3 Position => point.position;
        private Quaternion Rotation => point.rotation;

        private void Awake() => Instance = this;
        private void Update()
        {
            if (!_current || _target >= 1f) return;
            
            _target += Time.deltaTime * speed;
            _target = Mathf.Clamp01(_target);
            
            _current.transform.position = Vector3.Lerp(_current.OriginPosition, Position, curve.Evaluate(_target));
            _current.transform.rotation = Quaternion.Lerp(_current.OriginRotation, Rotation, curve.Evaluate(_target));
        }

        public bool SelectObject(InspectObjectSelectable selectable)
        {
            if (_current != null) return false;

            onStatusChanged.Invoke(true);
            _current = selectable;
            return true;
        }
        public void DeselectObject()
        {
            StartCoroutine(LeaveObject());
            onStatusChanged.Invoke(false);
        }

        private IEnumerator LeaveObject()
        {
            var target = _target;
            var current = _current;
            
            _target = 0f;
            _current = null;
            
            while (target > 0f)
            {
                yield return null;
                target -= Time.deltaTime * speed;
                
                current.transform.position = Vector3.Lerp(current.OriginPosition, Position, curve.Evaluate(_target));
                current.transform.rotation = Quaternion.Lerp(current.OriginRotation, Rotation, curve.Evaluate(_target));
            }
            
            current.ForceDisable();
        }
    }
}