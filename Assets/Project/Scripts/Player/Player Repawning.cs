using System.Collections;
using UnityEngine;

public class PlayerRepawning : MonoBehaviour
{
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField][Range(0, 10)] private float _disableColliderInSeconds = 1.5f;
    [SerializeField] private Transform[] _playerSpawnPoints;

    private Transform _playerSpawnPoint;
    private int _currentSpawnPointIndex = 0;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    private void Start() => _playerSpawnPoint = _playerSpawnPoints[_currentSpawnPointIndex];

    internal void OnLevelCompleted()
    {
        _currentSpawnPointIndex++;
        _playerSpawnPoint = _playerSpawnPoints[_currentSpawnPointIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.ObstacleTag))
        {
            gameObject.transform.position = _playerSpawnPoint.position;
            StartCoroutine(DisableColliders());
            StartCoroutine(FlashColor());
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