using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/Event", order = 1)]
public class GameEvents : ScriptableObject
{
    private UnityAction gameAction;

    public UnityAction GameAction
    { get { return gameAction; } set { gameAction = value; } }
}