using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenView : MonoBehaviour
{
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _procent;

    public void OpenLoadPanel()
    {
        _loadingPanel.SetActive(true);
    }

    public void CloseLoadPanel()
    {
        UpdateLoadingValue(0);
        _loadingPanel.SetActive(false);
    }

    public void UpdateLoadingValue(int value)
    {
        _slider.value = value;
        _procent.text = $"{value}%";
    }
}
