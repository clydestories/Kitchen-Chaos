using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] private Image _renderer;

    public void SetSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
    }
}
