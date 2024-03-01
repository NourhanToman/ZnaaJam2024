using System.Collections;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float rotationAngle = 45f;

    private Coroutine currentRotation;

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