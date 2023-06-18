using UnityEngine;

public class EntryGameScene : MonoBehaviour
{
    [SerializeField] private OrientationSettuper _orientationPrefab;
    [SerializeField] private LevelLoader _loaderPrefab;

    private void Start()
    {
        Instantiate(_orientationPrefab);
        Instantiate(_loaderPrefab).LoadNextLevel();
    }
}
