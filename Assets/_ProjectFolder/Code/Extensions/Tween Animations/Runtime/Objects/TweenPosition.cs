using PrimeTween;

namespace UnityEngine.Animations
{
    public abstract class TweenPosition : TweenTransform
    {
        [SerializeField] protected Direction direction;
        [SerializeField] protected float distance = 1f;

        protected override void Awake()
        {
            base.Awake();
            From = To = Transform.localPosition;
            To += direction.Get() * distance;
        }

        protected override void OnPlay(bool value)
        {
            base.OnPlay(value);

            TweenSettings = new(Transform.localPosition, value ? From : To, Settings);
            Tween = Tween.LocalPosition(Transform, TweenSettings);
            Tween.OnComplete(this, tween => tween.OnComplete());
        }
    }
}