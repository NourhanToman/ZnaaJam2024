using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineBrain brain;
    [SerializeField] internal CinemachineVirtualCamera[] virtualCamera;
    [SerializeField] private CinemachineVirtualCamera WinCam;
    [SerializeField] private GameEvents LevelComplete;
    [SerializeField] private GameEvents WinEvent;

    private readonly int on = 10;
    private readonly int off = 0;
    private int nextCam = 0;

    private void Awake() => ServiceLocator.Instance.RegisterService(this);

    private void OnEnable()
    {
        LevelComplete.GameAction += SwitchCam;
        WinEvent.GameAction += SwitchToWinCam;
    }

    private void OnDisable()
    {
        LevelComplete.GameAction -= SwitchCam;
        WinEvent.GameAction -= SwitchToWinCam;
    }

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

    private void SwitchToWinCam()
    {
        OffAllCams();
        WinCam.Priority = on;
        brain.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseOut, 0.5f);
    }
}