using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(KitchenItemSO))]
public class KitchenItemSOEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        var Item = (KitchenItemSO)target;

        if (Item == null || Item.Sprite == null)
        {
            return null;
        }

        Texture2D texture = new Texture2D(width, height);
        EditorUtility.CopySerialized(Item.Sprite.texture, texture);
        return texture;
    }
}
