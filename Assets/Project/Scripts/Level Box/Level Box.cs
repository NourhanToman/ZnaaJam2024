using System.Collections;
using UnityEngine;

public class LevelBox : MonoBehaviour
{
    [Header("Level Box Settings")]
    [SerializeField] private float rotationSpeed = 1f;

    [SerializeField] private float rotationAngle = 45f;
    [SerializeField] private float _playerScale = 2f;
    [SerializeField] private float _playerJumpForce = 1f;

    [Header("Obstacle Settings")]
    [SerializeField] private SpriteRenderer[] _obstacleSpriteRenderers;

    internal Collider2D Coolider2D { get; private set; }
    private Rigidbody2D rb;
    private float targetRotation;

    internal float PlayerScale => _playerScale;
    internal float PlayerJumpForce => _playerJumpForce;

    private void Awake()
    {
        Coolider2D = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(targetRotation - rb.rotation) > 0.01f)
        {
            float newRotation = Mathf.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(newRotation);
        }
    }

    internal void RotateRight() => targetRotation = rb.rotation + rotationAngle;

    internal void RotateLeft() => targetRotation = rb.rotation - rotationAngle;

    internal IEnumerator DisbaleObstcals()
    {
        yield return StartCoroutine(FadeOutObstacles(1f));
        SetObstacleToFalse();
    }

    internal void SetRandomInitialRotation(int randomDirection)
    {
        switch (randomDirection)
        {
            case 0: // Up
                targetRotation = 0;
                break;

            case 1: // Down
                targetRotation = 180;
                break;

            case 2: // Left
                targetRotation = 270;
                break;

            case 3: // Right
                targetRotation = 90;
                break;
        }
    }

    private IEnumerator FadeOutObstacles(float duration)
    {
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;

            foreach (SpriteRenderer renderer in _obstacleSpriteRenderers)
            {
                Color color = renderer.color;
                color.a = Mathf.Lerp(1, 0, t);
                renderer.color = color;
            }

            yield return null;
        }

        foreach (SpriteRenderer renderer in _obstacleSpriteRenderers)
        {
            Color color = renderer.color;
            color.a = 0;
            renderer.color = color;
        }

        SetObstacleToFalse();
    }

    private void SetObstacleToFalse()
    {
        foreach (SpriteRenderer renderer in _obstacleSpriteRenderers)
            renderer.gameObject.SetActive(false);
    }
}