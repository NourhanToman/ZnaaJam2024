using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField] GameEvents Collected;
    [SerializeField] Sprite Opaque;

    private void OnEnable()
    {
        Collected.GameAction += ChangeSprite;
    }
    private void OnDisable()
    {
        Collected.GameAction -= ChangeSprite;
    }
    void ChangeSprite()
    {
        gameObject.GetComponent<Image>().sprite = Opaque;
    }
}
