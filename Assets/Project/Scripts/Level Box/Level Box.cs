using System.Collections;
using UnityEngine;

public class LevelBox : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float rotationAngle = 45f;
    [SerializeField] private float _playerScale = 2f;
    [SerializeField] private float _playerJumpForce = 1f;

    internal Collider2D Coolider2D { get; private set; }

    private Coroutine currentRotation;
    internal float PlayerScale => _playerScale;
    internal float PlayerJumpForce => _playerJumpForce;

    private void Awake() => Coolider2D = GetComponent<Collider2D>();

    internal void RotateRight()
    {
        if (currentRotation != null)
            StopCoroutine(currentRotation);

        currentRotation = StartCoroutine(Rotate(Vector3.forward * rotationAngle));
    }

    internal void RotateLeft()
    {
        if (currentRotation != null)
            StopCoroutine(currentRotation);

        currentRotation = StartCoroutine(Rotate(Vector3.back * rotationAngle));
    }

    private IEnumerator Rotate(Vector3 rotation)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(rotation);

        float t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }
}