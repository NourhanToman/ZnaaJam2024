using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelUI : MonoBehaviour
{
    [SerializeField] Canvas loseCanvas;

    public void GameOverCanvas()
    {
        loseCanvas.gameObject.SetActive(true);
    }
   
    public void MainMenuBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        SceneManager.LoadSceneAsync(0);
    }
}
