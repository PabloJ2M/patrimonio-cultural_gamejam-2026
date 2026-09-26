namespace UnityEngine.Animations
{
    public class TweenPositionSwipe : TweenPosition
    {
        protected override void OnStart() => Transform.localPosition = TweenCore.IsEnabled ? From : To;

        [ContextMenu("SwipeIn")] public void SwipeIn() => TweenCore?.Play(true);
        [ContextMenu("SwipeOut")] public void SwipeOut() => TweenCore?.Play(false);
    }
}