using UnityEngine;

public static class Extensions
{
    public static int ToLayer(this LayerMask mask)
    {
        var bitmask = mask.value;
        var layerIndex = 0;
        
        while (bitmask > 1) {
            bitmask >>= 1;
            layerIndex++;
        }
        
        return layerIndex;
    }
    public static void SetLayerRecursively(this GameObject obj, int layer)
    {
        obj.layer = layer;
        
        foreach (Transform child in obj.transform)
            child.gameObject.SetLayerRecursively(layer);
    }
}