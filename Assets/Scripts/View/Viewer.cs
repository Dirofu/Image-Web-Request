using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    private Image _image;
    private ViewImage _view;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _view = FindObjectOfType<ViewImage>();
        _image.sprite = _view.ViewSprite;
        Destroy(_view.gameObject);
    }
}