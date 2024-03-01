using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera [] virtualCamera;

    int on = 10;
    int off = 0;
    int nextCam = 0;    
    private void Start()
    {
        offAllCams();
        virtualCamera[0].Priority = on;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCam();
        }
    }
    void SwitchCam()
    {
        if (nextCam < virtualCamera.Length-1)
        {
            nextCam++;
            offAllCams();
            virtualCamera[nextCam].Priority = on;
        }
        else if (nextCam >= virtualCamera.Length)
        {
            nextCam = virtualCamera.Length;
        }
    }
    void offAllCams()
    {
        for (int i = 0; i < virtualCamera.Length; i++)
        {
            virtualCamera[i].Priority = off;
        }
    }
}
