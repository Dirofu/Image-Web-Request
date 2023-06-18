using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Gallary : MonoBehaviour
{
    [SerializeField] private GallaryImage _gallaryImagePrefab;

    private LevelLoader _loader;

    private const string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";

    private void Awake()
    {
        _loader = FindObjectOfType<LevelLoader>();
    }

    private IEnumerator Start()
    {
        GallaryImage tempImage;
        Texture texture;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        for (int i = 1; i < int.MaxValue; i++)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture($"{_url}{i}.jpg");
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                break;
            
            texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            tempImage = Instantiate(_gallaryImagePrefab, transform);
            tempImage.InitializeImage((Texture2D)texture, this);
        }
    }

    public void OpenViewScene()
    {
        _loader.OpenView();
    }
}