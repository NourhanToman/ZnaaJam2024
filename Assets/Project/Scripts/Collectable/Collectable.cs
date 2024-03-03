using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Collectabe : MonoBehaviour
{
    [SerializeField] private GameEvents Collected;
    [SerializeField] private Sprite Opaque;

    private Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();

        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    private void OnEnable() => Collected.GameAction += ChangeSprite;

    private void OnDisable() => Collected.GameAction -= ChangeSprite;

    private void ChangeSprite() => StartCoroutine(FadeIn());

    private IEnumerator FadeIn()
    {
        Color color = image.color;
        for (float t = 0.01f; t < 1; t += Time.deltaTime)
        {
            color.a = t;
            image.color = color;
            yield return null;
        }
        color.a = 1;
        image.color = color;
    }
}