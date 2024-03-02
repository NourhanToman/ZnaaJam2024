using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;
    //[SerializeField] private RectTransform ControlsPanel;
    //[SerializeField] private RectTransform AudioPanel;

    public void StartGameBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        ServiceLocator.Instance.GetService<AudioManager>().PlayMusic("Level");

        //asyncLoad.completed += LoadSceneAndSetupCamera;
    }

    /*    private void LoadSceneAndSetupCamera(AsyncOperation asyncLoad)
        {
            Debug.Log(ServiceLocator.Instance.GetService<CameraManager>().name);

            // Now that the scene is loaded, set up the camera
            ServiceLocator.Instance.GetService<CameraManager>().OffAllCams();
            ServiceLocator.Instance.GetService<CameraManager>().virtualCamera[0].Priority = 0;
        }*/

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