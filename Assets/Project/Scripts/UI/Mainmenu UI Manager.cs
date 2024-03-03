using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;
    //[SerializeField] private RectTransform ControlsPanel;
    //[SerializeField] private RectTransform AudioPanel;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    public void StartGameBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1;

        ServiceLocator.GetService<AudioManager>().PlayMusic("Level");
        asyncLoad.completed += LoadSceneAndSetupCamera;
    }

    private void LoadSceneAndSetupCamera(AsyncOperation asyncLoad)
    {
        ServiceLocator.GetService<CameraManager>().StartCoroutineForCamera();

        Time.timeScale = 1;
    }

    public void SettingsBttn()
    {
        //MainPanel.gameObject.SetActive(false);
        SettingsPanel.gameObject.SetActive(true);
    }

    public void ExitBttn()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //in built ver
        //Application.Quit();
    }

    //////////////

    public void ReturnToMainBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        MainPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);
        //AudioPanel.gameObject.SetActive(false);
        //ControlsPanel.gameObject.SetActive(false);
    }
}