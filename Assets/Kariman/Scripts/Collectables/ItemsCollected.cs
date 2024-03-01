using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollected : MonoBehaviour
{
    [SerializeField] GameEvents Event;

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Event.GameAction?.Invoke();
            Destroy(gameObject);
        }
    }
}
