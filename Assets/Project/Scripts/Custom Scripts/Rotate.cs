using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10f;

    private void Update() => transform.Rotate(Vector3.forward, speed * Time.deltaTime);
}