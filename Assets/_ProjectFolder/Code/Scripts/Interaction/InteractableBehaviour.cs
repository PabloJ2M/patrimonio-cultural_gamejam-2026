using UnityEngine;

public abstract class InteractableBehaviour : MonoBehaviour, IInteractable
{
    private const string DefaultLayer = "Default";
    private const string BaseLayer = "Interactable";
    private const string HighlightLayer = "Highlight";
    
    protected bool IsSelected;
    
    public virtual void Select(bool isPressed)
    {
        gameObject.layer = LayerMask.NameToLayer(HighlightLayer);
        IsSelected = isPressed;
    }

    public virtual void Highlighted()
    {
        gameObject.layer = LayerMask.NameToLayer(DefaultLayer);
    }
    public virtual void UnHightlighted()
    {
        gameObject.layer = LayerMask.NameToLayer(BaseLayer);
        IsSelected = false;
    }

    public void ForceUnInteract() => Select(false);
}