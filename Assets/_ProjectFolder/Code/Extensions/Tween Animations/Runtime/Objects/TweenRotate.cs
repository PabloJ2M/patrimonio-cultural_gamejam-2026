namespace UnityEngine.Animations
{
    public class TweenRotate : TweenCustomVector
    {
        [SerializeField] protected float angle;

        protected override void Awake()
        {
            base.Awake();
            From = To = Transform.localEulerAngles;
            To += axis.Get() * -angle;
        }
        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);

            var time = animationCurve.Evaluate(value);
            Transform.localEulerAngles = Vector3.Lerp(From, To, time);
        }

        [ContextMenu("FlipIn")]
        public void RotateIn() => TweenCore?.Play(true);

        [ContextMenu("FlipOut")]
        public void RotateOut() => TweenCore?.Play(false);
    }
}