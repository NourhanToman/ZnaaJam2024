using UnityEngine;
using UnityEngine.UI;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Image[] starImages;

    private int starCount;
    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    private void Awake() => ServiceLocator.RegisterService(this);

    private void Start() => starCount = 0;

    public void WinCanvas(int count)
    {
        winCanvas.gameObject.SetActive(true);
        StarRate(count);

        ServiceLocator.GetService<AudioManager>().PlayMusic("Win");
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
        winCanvas.gameObject.SetActive(false);

        ServiceLocator.GetService<AudioManager>().PlaySFX("Button");
        ServiceLocator.GetService<Cutscene>().StartCutscene();
    }
}