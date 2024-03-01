using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.PlayerTag))
            collision.gameObject.transform.position = _serviceLocator.GetService<PlayerStartingPoint>().GetPlayerStartingPoint().position;
    }
}