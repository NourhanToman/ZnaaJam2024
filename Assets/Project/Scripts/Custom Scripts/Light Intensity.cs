using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensity : MonoBehaviour
{
    [SerializeField] private Light2D spotLight;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 2f;
    [SerializeField] private float flickerSpeed = 0.1f;


    private void Start()
    {
        if (spotLight == null)
            spotLight = GetComponent<Light2D>();

        StartCoroutine(FlickerLight());
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            float randomValue = Random.Range(minIntensity, maxIntensity);
            spotLight.intensity = randomValue;
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}