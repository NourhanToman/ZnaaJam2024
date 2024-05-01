using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] private Animator[] levelAnim;
    [SerializeField] private GameEvents levelCompleted;

    private int PrevLevel = 0;

    private void OnEnable() => levelCompleted.GameAction += ChangeTransparency;

    private void OnDisable() => levelCompleted.GameAction -= ChangeTransparency;

    private void ChangeTransparency()
    {
        levelAnim[PrevLevel].SetBool(GameConstant.Fade, true);

        if (PrevLevel < levelAnim.Length - 1)
            PrevLevel++;
        else if (PrevLevel >= levelAnim.Length)
            PrevLevel = levelAnim.Length;
    }
}