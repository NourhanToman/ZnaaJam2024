using System.Collections;
using UnityEngine;

public class PlayerRepawning : MonoBehaviour
{
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField][Range(0, 10)] private float _disableColliderInSeconds = 1.5f;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private GameEvents _gameEvents;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    private void Awake() => ServiceLocator.RegisterService(this);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.ObstacleTag))
        {
            ServiceLocator.GetService<AudioManager>().PlaySFX("Hit");

            gameObject.transform.position = _playerSpawnPoint.position;
            StartCoroutine(DisableColliders());
            StartCoroutine(FlashColor());

            _gameEvents.GameActionIntParameter?.Invoke(25);
        }
    }

    private IEnumerator DisableColliders()
    {
        _playerCollider.enabled = false;

        yield return new WaitForSeconds(_disableColliderInSeconds);

        _playerCollider.enabled = true;
    }

    private IEnumerator FlashColor()
    {
        var originalColor = _playerSpriteRenderer.color;

        for (int i = 0; i < 10; i++)
        {
            _playerSpriteRenderer.color = i % 2 == 0 ? Color.red : originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        _playerSpriteRenderer.color = originalColor;
    }
}