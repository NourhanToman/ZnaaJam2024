using UnityEngine;

public class TriggerLevelComplete : MonoBehaviour
{
    private LevelBoxManager _levelBoxManager;

    private void Start() => _levelBoxManager = ServiceLocator.Instance.GetService<LevelBoxManager>();

    private bool _isPlayerTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isPlayerTriggered && collision.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            _isPlayerTriggered = true;
            gameObject.SetActive(false);
            _levelBoxManager.levelCompleted.GameAction?.Invoke();
        }
    }
}