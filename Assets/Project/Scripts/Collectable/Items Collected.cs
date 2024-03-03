using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    [SerializeField] private GameEvents Event;

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GameConstant.PlayerTag))
        {
            Event.GameAction?.Invoke();
            Destroy(gameObject);
            Debug.Log("collected");
        }
    }
}