using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance = null;

    private LoadingScreenView _loadingView;
    private AsyncOperation _level;

    public int SceneCount => SceneManager.sceneCountInBuildSettings - 1;
    public int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;

    public static int GallarySceneIndex = 2;
    public static int ViewSceneIndex = 3;

    private void Awake()
    {
        _loadingView = GetComponent<LoadingScreenView>();
    }

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
        _loadingView.CloseLoadPanel();
    }

    public void LoadLevel(int levelID)
    {
        _level = SceneManager.LoadSceneAsync(levelID);
        OpenLoadScreen();
    }

    public void LoadLevel(string levelName)
    {
        _level = SceneManager.LoadSceneAsync(levelName);
        OpenLoadScreen();
    }

    public void LoadNextLevel()
    { 
        int id = SceneCount > CurrentSceneIndex ? CurrentSceneIndex + 1 : 0;
        LoadLevel(id);
    }

    public void OpenGallary() => LoadLevel(GallarySceneIndex);
    
    public void OpenView()
    {
        LoadLevel(ViewSceneIndex);
    }

    private void OpenLoadScreen()
    {
        _loadingView.OpenLoadPanel();
        StartCoroutine(AsyncLoadLevel());
    }

    private IEnumerator AsyncLoadLevel()
    {
        var waitForSeconds = new WaitForSeconds(1f);

        _level.allowSceneActivation = false;

        while (_level.isDone == false)
        {
            _loadingView.UpdateLoadingValue((int)(_level.progress * 100));

            yield return waitForSeconds;

            if (_level.progress >= 0.9f)
                _level.allowSceneActivation = true;

        }
        StopCoroutine(AsyncLoadLevel());
    }
}