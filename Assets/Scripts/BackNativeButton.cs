using UnityEngine;

public class BackNativeButton : MonoBehaviour
{
    private LevelLoader _loader;

    private void Awake()
    {
        _loader = FindObjectOfType<LevelLoader>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            _loader.OpenGallary();
    }
}
