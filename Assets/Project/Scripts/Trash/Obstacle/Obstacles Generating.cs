using UnityEngine;

public class ObsticalsGenerating : MonoBehaviour
{
    public GameObject obstaclePrefab; // Assign your obstacle prefab in the inspector
    public int numberOfObstacles = 10; // Number of obstacles to generate
    public GameObject box; // Assign your box GameObject in the inspector

    private void Start()
    {
        Bounds boxBounds = box.GetComponent<Renderer>().bounds;

        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 randomPositionOnEdge = GenerateRandomPositionOnEdge(boxBounds);
            Vector3 direction = (box.transform.position - randomPositionOnEdge).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90); // Subtract 90 to make the base face the center
            GameObject obstacle = Instantiate(obstaclePrefab, randomPositionOnEdge, rotation, box.transform);

            obstacle.transform.localScale = new Vector3(
                obstacle.transform.localScale.x / box.transform.localScale.x,
                obstacle.transform.localScale.y / box.transform.localScale.y,
                1
                );
        }
    }

    private Vector3 GenerateRandomPositionOnEdge(Bounds bounds)
    {
        Vector3 randomPositionInside = new Vector3(
            Random.Range(-bounds.extents.x, bounds.extents.x),
            Random.Range(-bounds.extents.y, bounds.extents.y),
            0
        );

        // Convert the position from local space to world space
        Vector3 randomPositionInWorld = box.transform.TransformPoint(randomPositionInside);

        // Calculate the direction from the center of the box to the random position
        Vector3 direction = (randomPositionInWorld - box.transform.position).normalized;

        // Move the random position to the edge of the box
        Vector3 randomPositionOnEdge = box.transform.position + direction * box.transform.localScale.x / 2;

        return randomPositionOnEdge;
    }
}