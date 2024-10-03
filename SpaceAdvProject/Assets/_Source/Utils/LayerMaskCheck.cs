using UnityEngine;

public static class LayerMaskCheck
{
    public static bool ContainsLayer(LayerMask layerMask, GameObject gameObject)
    {
        return (layerMask.value & (1 << gameObject.layer)) > 0;
    }
}