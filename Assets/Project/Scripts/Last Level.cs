using UnityEngine;

public class LastLevel : MonoBehaviour
{
    [SerializeField] private GameEvents _LastLevel;

    private bool _IsLevelComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_IsLevelComplete && collision.CompareTag(GameConstant.PlayerTag))
        {
            Debug.Log("Level Complete");
            _LastLevel.GameAction?.Invoke();
        }
    }
}