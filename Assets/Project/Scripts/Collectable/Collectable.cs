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

    private void OnEnable() => Collected.GameAction += IncreaseTransparency;

    private void OnDisable() => Collected.GameAction -= IncreaseTransparency;

    private void IncreaseTransparency() => StartCoroutine(IncreaseTransparencyCoroutine());

    private IEnumerator IncreaseTransparencyCoroutine()
    {
        Color color = image.color;
        float targetAlpha = color.a + 0.33f;
        if (targetAlpha > 1) targetAlpha = 1;

        while (color.a < targetAlpha)
        {
            color.a += Time.deltaTime * 0.33f;
            image.color = color;
            yield return null;
        }
    }
}