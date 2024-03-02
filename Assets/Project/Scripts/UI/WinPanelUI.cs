using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] Image[] starImages;

    private int starCount;


    private void Start()
    {
        starCount = 0;
    }


    public void WinCanvas(int count)
    {
        winCanvas.gameObject.SetActive(true);
        StarRate(count);
    }
    public void StarRate(int count)
    {
        starCount = count;
        for (int i = 0; i < starCount; i++)
        {
            starImages[i].color = 
                new Color(starImages[i].color.r, starImages[i].color.g, starImages[i].color.b, 1f);
        }
    }
    public void MainMenuBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        SceneManager.LoadSceneAsync(0);
    }
}
