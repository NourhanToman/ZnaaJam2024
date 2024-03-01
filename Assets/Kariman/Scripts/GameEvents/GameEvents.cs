using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/Event", order = 1)]
public class GameEvents : ScriptableObject
{
    UnityAction gameAction;
    public UnityAction GameAction { get { return gameAction; } set { gameAction = value; } }
}
