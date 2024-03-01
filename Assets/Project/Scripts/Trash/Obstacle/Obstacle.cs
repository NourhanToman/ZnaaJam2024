using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);
    }
}