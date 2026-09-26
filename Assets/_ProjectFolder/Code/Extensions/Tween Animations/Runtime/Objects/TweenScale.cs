namespace UnityEngine.Animations
{
    public class TweenScale : TweenCustomVector
    {
        [SerializeField] private ScaleFactor factor;
        [SerializeField] private bool invert;
        
        protected override void Awake()
        {
            base.Awake();
            
            From = Transform.localScale - axis.Get() * factor.Normal;
            To = Transform.localScale - axis.GetInverse() * factor.Scaled;
        }
        protected override void OnUpdate(float value)
        {
            base.OnUpdate(value);

            var time = animationCurve.Evaluate(value);
            Transform.localScale = Vector3.LerpUnclamped(From, To, invert ? 1f - time : time);
        }

        public void ScaleIn() => TweenCore.Play(true);
        public void ScaleOut() => TweenCore.Play(false);
    }
}