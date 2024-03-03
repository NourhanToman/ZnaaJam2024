using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevel : MonoBehaviour
{
    [SerializeField] private GameEvents _LastLevel;

    private bool _IsLevelComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_IsLevelComplete && collision.CompareTag(GameConstant.PlayerTag))
            _LastLevel.GameAction?.Invoke();
    }
}