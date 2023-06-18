using UnityEngine;

public class OrientationSettuper : MonoBehaviour
{
    public static OrientationSettuper Instance = null;

    private const int _autoRotationSceneIndex = 3;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == _autoRotationSceneIndex)
            Screen.orientation = ScreenOrientation.AutoRotation;
        else
            Screen.orientation = ScreenOrientation.Portrait;
    }
}
