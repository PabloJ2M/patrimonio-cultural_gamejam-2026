using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseButton;
    [SerializeField] private TweenCore effect;
    [SerializeField] private CursorHandler cursor;
    
    public bool IsPaused { get; private set; }

    private void OnEnable() => pauseButton.action.performed += SwitchPause;
    private void OnDisable() => pauseButton.action.performed -= SwitchPause;

    public void SwitchPause(InputAction.CallbackContext _) => SetPause(!IsPaused);
    public void Pause() => SetPause(true);
    public void UnPause() => SetPause(false);

    private void SetPause(bool value)
    {
        IsPaused = value;
        
        effect?.Play(value);
        cursor?.SetCursorStatus(IsPaused);
        
        Time.timeScale = value ? 0 : 1;
    }
}