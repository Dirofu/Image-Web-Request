using UnityEngine;

public class MenuButtonActions : MonoBehaviour
{
    private LevelLoader _loader;

    public void OpenGallary()
    {
        if (_loader == null)
            _loader = FindObjectOfType<LevelLoader>();

        _loader.OpenGallary();
    }
}
