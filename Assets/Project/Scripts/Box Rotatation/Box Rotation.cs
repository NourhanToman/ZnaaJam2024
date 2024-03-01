using System.Collections;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;

    internal void RotateRight()
    {
        StartCoroutine(Rotate(Vector3.forward * 10));
    }

    internal void RotateLeft()
    {
        StartCoroutine(Rotate(Vector3.back * 10));
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