using UnityEngine;

public static class GameConstant
{
    public const string PlayerTag = "Player";
    public const string GroundTag = "Ground";
    public const string ObstacleTag = "Obstacle";

    public const string LevelCompleteTag = "Level Complete";
    public const string LevelFinishTag = "Level Finish";
    public const string LastLevelTag = "Last Level";

    public const string DropletWaterTag = "Droplet Water";
    public const string FertilizerTag = "Fertilizer";
    public const string SunlightTag = "Sunlight";

    public static int Fade = Animator.StringToHash("Fade");
    public static int Win = Animator.StringToHash("Win");
}