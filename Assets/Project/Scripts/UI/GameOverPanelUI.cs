using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelUI : MonoBehaviour
{
    [SerializeField] private Canvas loseCanvas;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    public void GameOverCanvas() => loseCanvas.gameObject.SetActive(true);

    public void MainMenuBttn()
    {
        ServiceLocator.Instance.GetService<AudioManager>().PlaySFX("Button");
        SceneManager.LoadSceneAsync(0);
    }
}