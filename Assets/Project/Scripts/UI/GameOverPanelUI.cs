using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelUI : MonoBehaviour
{
    [SerializeField] private Canvas loseCanvas;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    private AudioManager audioManager;

    private void Awake() => ServiceLocator.RegisterService(this);

    private void Start() => audioManager = ServiceLocator.GetService<AudioManager>();

    public void GameOverCanvas()
    {
        loseCanvas.gameObject.SetActive(true);
        audioManager.PlayMusic("Lose");
    }

    public void MainMenuBttn()
    {
        audioManager.PlaySFX("Button");
        SceneManager.LoadSceneAsync(0);
    }
}