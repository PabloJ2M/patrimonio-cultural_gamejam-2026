using UnityEngine;
using UnityEngine.Splines;

public class SplineAnimator : MonoBehaviour
{
    [SerializeField] private SplineAnimate animate;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve curve;
    
    private static readonly int Speed = Animator.StringToHash("Speed");

    public async void RefreshAnimator()
    {
        await Awaitable.WaitForSecondsAsync(0.1f);
        animator = GetComponentInChildren<Animator>();
    }
    // private async void OnEnable()
    // {
    //     await Awaitable.WaitForSecondsAsync(0.1f);
    //     animator = GetComponentInChildren<Animator>();
    // }
    private void Update()
    {
        if (!animator) return;
        
        if (animate.IsPlaying)
            animator?.SetFloat(Speed, curve.Evaluate(animate.ElapsedTime / animate.Duration));
        else
            animator?.SetFloat(Speed, 0);
    }
}