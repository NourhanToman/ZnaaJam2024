using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameEvents levelCompleted;
    private bool levelCompletedTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!levelCompletedTriggered && other.gameObject.CompareTag("Level Complete"))
        {
            levelCompletedTriggered = true;
            levelCompleted.GameAction?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        levelCompletedTriggered = false;
    }
}