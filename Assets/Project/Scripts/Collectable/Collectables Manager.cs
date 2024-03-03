using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] private GameEvents Collected;
    [SerializeField] private Sprite Opaque;

    private Image image;
    private ServiceLocator _serviceLocator;

    internal int _dropletWaterCounter = 0;
    internal int _fertilizerCounter = 0;
    internal int _sunlightCounter = 0;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);
    }

    private void Start()
    {
        image = gameObject.GetComponent<Image>();

        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    private void OnEnable() => Collected.GameAction += ChangeSprite;

    private void OnDisable() => Collected.GameAction -= ChangeSprite;

    //private void ChangeSprite() => gameObject.GetComponent<Image>().sprite = Opaque;
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