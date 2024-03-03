using System.Collections;
using UnityEngine;

public class PlayerLevelComplete : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] private Transform _parent;

    [SerializeField] private Collider2D[] _playerCollider;
    [SerializeField] private GameObject[] _playerCracks;

    [Header("Fade Out Children")]
    [SerializeField] private StayInCollider2D[] stayInColliders;

    [SerializeField] private SpriteRenderer[] _fadeOut;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.LevelFinishTag))
        {
            foreach (var collider in _playerCollider)
                collider.enabled = false;

            foreach (var crack in _playerCracks)
            {
                crack.SetActive(true);
                crack.transform.SetParent(_parent);
            }

            foreach (Transform child in transform)
            {
                foreach (var stayInCollider in stayInColliders)
                {
                    stayInCollider.enabled = false;

                    if (stayInCollider.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
                        rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                }

                child.SetParent(_parent);
            }

            foreach (var crack in _playerCracks)
            {
                if (crack.TryGetComponent<Rigidbody2D>(out var rb))
                    rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
            }

            StartCoroutine(FadeOutChildren());
        }
    }

    private IEnumerator FadeOutChildren()
    {
        float fadeSpeed = 0.05f; // Adjust this value to control the speed of the fade out

        foreach (var sprite in _fadeOut)
        {
            Color spriteColor = sprite.color;

            while (spriteColor.a > 0)
            {
                spriteColor.a -= fadeSpeed;
                sprite.color = spriteColor;
                yield return new WaitForSeconds(0.1f); // Adjust this value to control the delay between each fade step
            }
        }

        gameObject.SetActive(false);
    }
}