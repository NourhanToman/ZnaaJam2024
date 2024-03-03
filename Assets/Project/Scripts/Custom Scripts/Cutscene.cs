using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneParent;
    [SerializeField] private Image cutsceneBackground;
    [SerializeField] private Image cutsceneImage;
    [SerializeField] private List<Sprite> cutsceneFrames;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private bool isFinalCutscene = false;

    internal bool IsCutscenePlaying { get; private set; }

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    private void Awake() => ServiceLocator.RegisterService(this);

    private void Start()
    {
        // Set the size of the image to match the screen size
        RectTransform rectTransformCutsceneImage = cutsceneImage.GetComponent<RectTransform>();
        rectTransformCutsceneImage.sizeDelta = new Vector2(Screen.width, Screen.height);

        RectTransform rectTransformBackground = cutsceneBackground.GetComponent<RectTransform>();
        rectTransformBackground.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void StartCutscene()
    {
        IsCutscenePlaying = true;

        cutsceneParent.SetActive(true);

        Time.timeScale = 0;

        ServiceLocator.GetService<AudioManager>().PlayMusic("End");

        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        foreach (Sprite frame in cutsceneFrames)
        {
            cutsceneImage.sprite = frame;
            yield return FadeIn();
            yield return new WaitForSecondsRealtime(2);
            yield return FadeOut();
        }

        cutsceneParent.SetActive(false);
        ServiceLocator.GetService<InputManager>().PlayerInput.Enable();
        cutsceneParent.SetActive(false);

        if (isFinalCutscene)
            ReturnToMainMenu();

        IsCutscenePlaying = false;
    }

    private IEnumerator FadeIn()
    {
        float t = 0;
        while (t < transitionTime)
        {
            t += Time.unscaledDeltaTime;
            Color color = cutsceneImage.color;
            color.a = Mathf.Lerp(0, 1, t / transitionTime);
            cutsceneImage.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float t = 0;
        while (t < transitionTime)
        {
            t += Time.unscaledDeltaTime;
            Color color = cutsceneImage.color;
            color.a = Mathf.Lerp(1, 0, t / transitionTime);
            cutsceneImage.color = color;
            yield return null;
        }
    }

    private void ReturnToMainMenu() => SceneManager.LoadScene(0);
}