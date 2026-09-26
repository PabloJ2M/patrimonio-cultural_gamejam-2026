namespace UnityEngine.InputSystem
{
    public abstract class ActionBase : MonoBehaviour
    {
        protected InputSystem_Actions Actions;
        
        protected virtual void Awake() => Actions = new InputSystem_Actions();
        protected virtual void OnEnable() => Actions.Enable();
        protected virtual void OnDisable() => Actions.Disable();
    }
}