using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerLevelComplete : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] private Transform _parent;

    [SerializeField] private Collider2D[] _playerCollider;
    [SerializeField] private GameObject[] _playerCracks;

    [Header("Fade Out Children")]
    [SerializeField] private StayInCollider2D[] stayInColliders;

    [SerializeField] private SpriteRenderer[] _fadeOut;

    [Header("Win Animator")]
    [SerializeField] private Animator[] _animator;

    private ServiceLocator _serviceLocator;
    private CollectablesManager _collectablesManager;

    [Header("Event")]
    [SerializeField] private GameEvents _gameEvents;

    private int count = 0;

    private void Awake() => _serviceLocator = ServiceLocator.Instance;

    private void Start() => _collectablesManager = _serviceLocator.GetService<CollectablesManager>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.LevelFinishTag))
        {
            _gameEvents.GameAction?.Invoke();

            foreach (var collider in _playerCollider)
                collider.enabled = false;

            foreach (var crack in _playerCracks)
            {
                crack.SetActive(true);
                crack.transform.SetParent(_parent);
            }

            foreach (Transform child in transform)
            {
                foreach (var stayInCollider in stayInColliders)
                {
                    stayInCollider.enabled = false;

                    if (stayInCollider.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
                        rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                }

                child.SetParent(_parent);
            }

            foreach (var crack in _playerCracks)
            {
                if (crack.TryGetComponent<Rigidbody2D>(out var rb))
                    rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
            }

            StartCoroutine(FadeOutChildren());
        }
    }

    private IEnumerator FadeOutChildren()
    {
        float fadeSpeed = 0.05f;

        foreach (var sprite in _fadeOut)
        {
            Color spriteColor = sprite.color;

            while (spriteColor.a > 0)
            {
                spriteColor.a -= fadeSpeed;
                sprite.color = spriteColor;
                yield return new WaitForSeconds(0.1f);
            }
        }

        CheckPlayerWinCondition();

        _playerCollider[0].gameObject.SetActive(false);
    }

    private void CheckPlayerWinCondition()
    {
        int[] counters = new int[] { _collectablesManager._dropletWaterCounter, _collectablesManager._fertilizerCounter, _collectablesManager._sunlightCounter };

        while (counters.All(c => c > 0))
        {
            count++;
            for (int i = 0; i < counters.Length; i++)
            {
                counters[i]--;
            }
        }

        for (int i = 0; i < count; i++)
        {
            _animator[i].gameObject.SetActive(true);
            _animator[i].SetBool(GameConstant.Win, true);
        }

        CheckCount();

        // StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(5f);

        // Call the CheckCount function after the animation has finished
        CheckCount();
    }

    private void CheckCount()
    {
        if (count == 1)
        {
            // 1 star
            Debug.Log("1 star");
            ServiceLocator.Instance.GetService<WinPanelUI>().WinCanvas(1);
        }
        else if (count == 2)
        {
            // 2 stars
            Debug.Log("2 stars");
            ServiceLocator.Instance.GetService<WinPanelUI>().WinCanvas(2);
        }
        else if (count == 3)
        {
            // 3 stars
            Debug.Log("3 stars");
            ServiceLocator.Instance.GetService<WinPanelUI>().WinCanvas(3);
        }
        else
        {
            //lose
            Debug.Log("lose");
            ServiceLocator.Instance.GetService<GameOverPanelUI>().GameOverCanvas();
        }
    }
}