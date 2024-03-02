using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] internal CinemachineVirtualCamera[] virtualCamera;
    [SerializeField] private GameEvents LevelComplete;

    private readonly int on = 10;
    private readonly int off = 0;
    private int nextCam = 0;

    private void Start()
    {
        OffAllCams();
        virtualCamera[0].Priority = on;
    }

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

    internal void OffAllCams()
    {
        for (int i = 0; i < virtualCamera.Length; i++)
            virtualCamera[i].Priority = off;
    }

    private void LateUpdate()
    {
        
    }
}