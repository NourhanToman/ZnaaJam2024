using UnityEngine;

public class StayInsideCircle : MonoBehaviour
{
    [SerializeField] private GameObject circleGameObject;

    private Transform circleCenter;
    private float circleRadius;

    private void Start()
    {
        // Get the center of the circle
        circleCenter = circleGameObject.transform;

        // Get the radius of the circle
        circleRadius = circleGameObject.GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        // Calculate the distance from the object to the center of the circle
        Vector2 direction = transform.position - circleCenter.position;
        float distance = direction.magnitude;

        // If the object is outside the circle, move it back to the edge of the circle
        if (distance > circleRadius)
        {
            Vector2 positionOnCircleEdge = (Vector2)circleCenter.position + direction.normalized * circleRadius;
            transform.position = positionOnCircleEdge;
        }
    }
}