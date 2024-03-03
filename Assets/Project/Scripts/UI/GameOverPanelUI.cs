using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelUI : MonoBehaviour
{
    [SerializeField] private Canvas loseCanvas;

    public void GameOverCanvas() => loseCanvas.gameObject.SetActive(true);

    public void MainMenuBttn()
    {
        ServiceLocator.Instance.GetService<AudioManager>().PlaySFX("Button");
        SceneManager.LoadSceneAsync(0);
    }
}