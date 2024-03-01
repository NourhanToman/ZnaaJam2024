using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvents/Event", order = 1)]
public class GameEvents : ScriptableObject
{
    private UnityAction gameAction;
    private UnityAction<int> _gameActionIntParameter;

    public UnityAction GameAction
    { get { return gameAction; } set { gameAction = value; } }

    public UnityAction<int> GameActionIntParameter
    { get { return _gameActionIntParameter; } set { _gameActionIntParameter = value; } }
}