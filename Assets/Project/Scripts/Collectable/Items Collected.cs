using System.Collections;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    [SerializeField] private GameEvents Event;
    [SerializeField] private float fadeOutDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _serviceLocator = ServiceLocator.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            Event.GameAction?.Invoke();
            CheckItemTag();
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

        gameObject.SetActive(false);
    }

    private void CheckItemTag()
    {
        if (gameObject.CompareTag(GameConstant.DropletWaterTag))
            _serviceLocator.GetService<CollectablesManager>()._dropletWaterCounter++;
        else if (gameObject.CompareTag(GameConstant.FertilizerTag))
            _serviceLocator.GetService<CollectablesManager>()._fertilizerCounter++;
        else if (gameObject.CompareTag(GameConstant.SunlightTag))
            _serviceLocator.GetService<CollectablesManager>()._sunlightCounter++;
    }
}