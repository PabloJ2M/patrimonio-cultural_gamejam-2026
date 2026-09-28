using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private bool isVisible;
    private bool _wasForced;
    
    private void Start() => SetCursorStatus(isVisible);

    public void SetCursorStatus(bool isCursorVisible)
    {
        if (_wasForced) return;
        print("set status");
        
        Cursor.visible = isCursorVisible;
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
        crosshair.SetActive(!isCursorVisible);
    }
    
    public void CursorLook() => SetCursorStatus(false);
    public void CursorUnlock() => SetCursorStatus(true);

    public void CursorLookForced()
    {
        _wasForced = false;
        CursorLook();
    }
    public void CursorUnLookForced()
    {
        CursorUnlock();
        _wasForced = true;
        print("unlocked");
    }
}