using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeLookCameraOverride : MonoBehaviour
{

    private CinemachineFreeLook freeLookCam;
    //private float originalPosition;

    float duration = 30.0f;

    float startTime;



    //CinemachineOrbitalTransposer.

    // Start is called before the first frame update
    void Start()
    {
        freeLookCam = GetComponent<CinemachineFreeLook>();
        startTime = Time.time;
        //originalPosition = freeLookCam.m_YAxis.Value;


    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        freeLookCam.m_YAxis.Value = Mathf.SmoothStep(freeLookCam.m_YAxis.Value, 0, t);
        //Mathf.Lerp(freeLookCam.m_YAxis.Value, 0.31f, Mathf.SmoothStep(0.0, 1.0, 5));
        //Mathf.Lerp(freeLookCam.m_YAxis.Value, 0.31f, Time.deltaTime * freeLookCam.m_YAxis.m_MaxSpeed);
        //Mathf.Lerp(originalPosition, 0.31f, Time.deltaTime * freeLookCam.m_YAxis.m_MaxSpeed);
    }
}
