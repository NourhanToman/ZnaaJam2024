using UnityEngine;

public static class GameConstant
{
    public const string PlayerTag = "Player";
    public const string GroundTag = "Ground";
    public const string ObstacleTag = "Obstacle";
    public const string LevelCompleteTag = "Level Complete";

    public static int Fade = Animator.StringToHash("Fade");
}