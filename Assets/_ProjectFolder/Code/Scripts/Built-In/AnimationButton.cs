using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animation), typeof(Button3D))]
public class AnimationButton : MonoBehaviour
{
    private Animation _animation;
    private Button3D _button;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _button = GetComponent<Button3D>();
    }

    private void OnEnable() => _button.OnClick.AddListener(Play);
    private void OnDisable() => _button.OnClick.RemoveListener(Play);

    private void Play() => _animation.Play();
}