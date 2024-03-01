using UnityEngine;

public class StayInCollider2D : MonoBehaviour
{
    [SerializeField] private CircleCollider2D boundary;

    private void Update()
    {
        Vector3 pos = transform.position;
        Vector3 center = boundary.bounds.center;
        float radius = boundary.radius;

        Vector3 direction = pos - center;
        if (direction.magnitude > radius)
        {
            direction = direction.normalized * radius;
            pos = center + direction;
        }

        transform.position = pos;
    }
}