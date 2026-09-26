using UnityEngine;
using UnityEngine.Events;

public class SelectableObject : InteractableBehaviour
{
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDeselect;

    public override void Select(bool isPressed)
    {
        base.Select(isPressed);
        
        if (isPressed)
            onSelect.Invoke();
        else
            onDeselect.Invoke();
    }
}