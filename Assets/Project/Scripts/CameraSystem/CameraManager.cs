using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] internal CinemachineVirtualCamera[] virtualCamera;
    [SerializeField] private GameEvents LevelComplete;

    private readonly int on = 10;
    private readonly int off = 0;
    private int nextCam = 0;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    private void OnEnable() => LevelComplete.GameAction += SwitchCam;

    private void OnDisable() => LevelComplete.GameAction -= SwitchCam;

    private void SwitchCam()
    {
        if (nextCam < virtualCamera.Length - 1)
        {
            nextCam++;
            OffAllCams();
            virtualCamera[nextCam].Priority = on;
        }
        else if (nextCam >= virtualCamera.Length)
            nextCam = virtualCamera.Length;
    }

    internal void StartCoroutineForCamera() => StartCoroutine(StartCameraZoomIn());

    private IEnumerator StartCameraZoomIn()
    {
        for (int i = virtualCamera.Length - 1; i >= 0; i--)
        {
            OffAllCams();
            virtualCamera[i].Priority = on;
            yield return null;
        }
    }

    internal void OffAllCams()
    {
        for (int i = 0; i < virtualCamera.Length; i++)
            virtualCamera[i].Priority = off;
    }
}