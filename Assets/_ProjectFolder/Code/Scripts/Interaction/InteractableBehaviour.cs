using UnityEngine;

public abstract class InteractableBehaviour : MonoBehaviour, IInteractable
{
    private const string DefaultLayer = "Default";
    private const string BaseLayer = "Interactable";
    private const string HighlightLayer = "Highlight";
    
    protected bool IsSelected;
    protected bool IsHighlighted;
    
    public virtual void Select(bool isPressed)
    {
        gameObject.SetLayerRecursively(LayerMask.NameToLayer(DefaultLayer));
        gameObject.SetLayerRecursively(LayerMask.NameToLayer(DefaultLayer));
        IsSelected = isPressed;
    }

    public virtual void Highlighted()
    {
        if (IsHighlighted) return;
        
        gameObject.SetLayerRecursively(LayerMask.NameToLayer(HighlightLayer));
        IsHighlighted = true;
    }
    public virtual void UnHightlighted()
    {
        if (!IsHighlighted) return;
        
        gameObject.SetLayerRecursively(LayerMask.NameToLayer(BaseLayer));
        IsSelected = IsHighlighted = false;
    }

    public void ForceUnInteract() => Select(false);
}