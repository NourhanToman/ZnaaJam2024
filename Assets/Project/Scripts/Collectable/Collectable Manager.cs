using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    internal int _dropletWaterCounter = 0;
    internal int _fertilizerCounter = 0;
    internal int _sunlightCounter = 0;
}