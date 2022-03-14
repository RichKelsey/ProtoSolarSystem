using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera povCam;
    public Cinemachine.CinemachineVirtualCamera mapCam;

    // Start is called before the first frame update
    void Start()
    {
        povCam.Priority = 0;
        mapCam.Priority = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //swap between cams based on key presses, priority decides this and is a value between 0 and 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mapCam.Priority = 0;
            povCam.Priority = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            povCam.Priority = 0;
            mapCam.Priority = 1;
        }
    }
}
