using UnityEngine;

public class BoxRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    private int rotationDirection = 1; // 1 for right, -1 for left

    private void Start()
    {
        // Randomly set the initial rotation direction
        rotationDirection = Random.Range(0, 2) * 2 - 1; // will be either -1 or 1
    }

    private void Update()
    {
        // Rotate the cube
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * rotationDirection);
    }

    internal void FlipRotation() => rotationDirection *= -1;
}