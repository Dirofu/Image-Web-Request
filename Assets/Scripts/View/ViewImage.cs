using UnityEngine;

public class ViewImage : MonoBehaviour
{
    public Sprite ViewSprite { get; private set; }

    public void SetSprite(Sprite sprite)
    {
        ViewSprite = sprite;
    }
}
