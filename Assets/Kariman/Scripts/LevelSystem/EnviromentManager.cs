using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] Animator [] levelAnim;
    [SerializeField] private GameEvents levelCompleted;
    int PrevLevel = 0;

    private void OnEnable() => levelCompleted.GameAction += ChangeTransparency;

    private void OnDisable() => levelCompleted.GameAction -= ChangeTransparency;

    void ChangeTransparency()
    {
        levelAnim[PrevLevel].SetBool("Fade", true);

        if(PrevLevel < levelAnim.Length - 1)
        {
            PrevLevel++;
        }
        else if (PrevLevel >= levelAnim.Length)
        {
            PrevLevel = levelAnim.Length;
        }
    }
}
