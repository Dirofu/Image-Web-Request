using UnityEngine;
using UnityEngine.UI;

public class GallaryImage : MonoBehaviour
{
    [SerializeField] private ViewImage _viewImagePrefab;
    [SerializeField] private Image _image;

    private Gallary _gallary;

    public void InitializeImage(Texture2D image, Gallary gallary)
    {
        _image.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), Vector2.one / 2);
        _gallary = gallary;
    }

    public void OpenViewScene()
    {
        SaveViewImage();
        _gallary.OpenViewScene();
    }

    private void SaveViewImage()
    {
        ViewImage view = Instantiate(_viewImagePrefab);
        DontDestroyOnLoad(view.gameObject);
        view.SetSprite(_image.sprite);
    }
}
