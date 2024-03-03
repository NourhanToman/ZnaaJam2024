using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private Image dropletWater;
    [SerializeField] private Image fertilizer;
    [SerializeField] private Image sunlight;

    internal int _dropletWaterCounter = 0;
    internal int _fertilizerCounter = 0;
    internal int _sunlightCounter = 0;
}