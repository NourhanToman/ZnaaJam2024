using System.Collections;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    [SerializeField] private GameEvents Event;
    [SerializeField] private float fadeOutDuration = 1f;

    private SpriteRenderer spriteRenderer;

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            Event.GameAction?.Invoke();
            StartCoroutine(FadeOutAndDestroy());
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float startTime = Time.time;

        while (Time.time - startTime < fadeOutDuration)
        {
            float t = (Time.time - startTime) / fadeOutDuration;
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(1, 0, t);
            spriteRenderer.color = color;
            yield return null;
        }

        Destroy(gameObject);
    }
}