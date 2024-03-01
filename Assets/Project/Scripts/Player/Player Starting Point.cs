using UnityEngine;

public class PlayerStartingPoint : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    internal Transform GetPlayerStartingPoint() => playerSpawnPoint;
}