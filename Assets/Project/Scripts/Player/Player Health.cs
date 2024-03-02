using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 100;
    [SerializeField] private Sprite[] _healthSprite;
    [SerializeField] private GameEvents _gameEvents;

    private SpriteRenderer _spriteRenderer;

    private void Awake() => _gameEvents.GameActionIntParameter += CalculateHealth;

    private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();

    private void OnDestroy() => _gameEvents.GameActionIntParameter -= CalculateHealth;

    private int _healthSpriteIndex = 0;

    public void CalculateHealth(int damage)
    {
        if (_healthSpriteIndex >= _healthSprite.Length)
            return;

        _playerHealth -= damage;

        if (_playerHealth <= 75)
        {
            _spriteRenderer.sprite = _healthSprite[_healthSpriteIndex];
            _healthSpriteIndex++;
        }
        else if (_playerHealth <= 50)
        {
            _spriteRenderer.sprite = _healthSprite[_healthSpriteIndex];
            _healthSpriteIndex++;
        }
        else if (_playerHealth <= 25)
            _spriteRenderer.sprite = _healthSprite[_healthSpriteIndex];
        else if (_playerHealth <= 0)
        {
            ServiceLocator.Instance.GetService<AudioManager>().PlaySFX("Game Over");
        }
    }
}