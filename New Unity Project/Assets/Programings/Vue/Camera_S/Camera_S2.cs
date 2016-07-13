using UnityEngine;
using System.Collections;
using System;

public class Camera_S2 : MonoBehaviour
{
    //Déclaration Des Variables De 
    Vector3 FPSPositionStart, RTSPositionStart, FPSPositionEnd, RTSPositionEnd;
    Quaternion FPSRotationStart, RTSRotationStart, FPSRotationEnd, RTSRotationEnd;
    public float driftSeconds = 3;
    private float driftTimer = 0.3f;
    private bool isDriftingtoTPS = false;
    private bool isDriftingtoRTS = false;
    private bool isDriftingtoFPS = false;
    // Use this for initialization
    void Start()
    {

        //AVoir Le Transform De La Camera Pour La position A Bouger
        RTSPositionStart = GameObject.Find("_Position_RTS_").GetComponent<Transform>().position;
        RTSRotationStart = GameObject.Find("_Position_RTS_").GetComponent<Transform>().rotation;
        FPSPositionStart = GameObject.Find("_Position_FPS_").GetComponent<Transform>().position;
        FPSRotationStart = GameObject.Find("_Position_FPS_").GetComponent<Transform>().rotation;
        RTSPositionEnd = GameObject.Find("_Position_RTS_").GetComponent<Transform>().position;
        RTSRotationEnd = GameObject.Find("_Position_RTS_").GetComponent<Transform>().rotation;
        FPSPositionEnd = GameObject.Find("_Position_FPS_").GetComponent<Transform>().position;
        FPSRotationEnd = GameObject.Find("_Position_FPS_").GetComponent<Transform>().rotation;

    }

    private void StartDrifttoFPSFromRTS()
    {
        isDriftingtoFPS = true;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        driftTimer = 0;
        RTSPositionStart = transform.position;
        RTSRotationStart = transform.rotation;


    }
    private void StopDrifttoFPSfromRTS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        transform.position = FPSPositionEnd;
        transform.rotation = FPSRotationEnd;

    }
    private void StartDrifttoTPSfromRTS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = true;
        driftTimer = 0;
        RTSPositionStart = transform.position;
        RTSRotationStart = transform.rotation;


    }
    private void StopDrifttoTPSfromRTS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        transform.position = RTSPositionEnd;
        transform.rotation = RTSRotationEnd;

    }
    private void StartDrifttoRTSfromTPS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = true;
        isDriftingtoTPS = false;
        driftTimer = 0;
        var TPSPositionStart = transform.position;
        RTSRotationStart = transform.rotation;


    }
    private void StopDrifttoRTStoRTSfromTPS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        driftTimer = 0;
        transform.position = FPSPositionEnd;
        transform.rotation = FPSRotationEnd;

    }

    private void StartDriftfromTPS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        driftTimer = 0;
        RTSPositionStart = transform.position;
        RTSRotationStart = transform.rotation;


    }
    private void StopDriftfromTPS()
    {
        isDriftingtoFPS = false;
        isDriftingtoRTS = false;
        isDriftingtoTPS = false;
        transform.position = FPSPositionEnd;
        transform.rotation = FPSRotationEnd;

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            StartDrifttoFPSFromRTS();
        }else if (Input.GetButton("Fire2"))
        {
            StartDrifttoFPSFromRTS();
        }
        else if (Input.GetButton("Fire3"))
        {
            StartDrifttoFPSFromRTS();
        }

        if (isDriftingtoFPS == false)
        {
            driftTimer += Time.deltaTime;
            if(driftTimer > driftSeconds)
            {

                StopDrifttoFPSfromRTS();
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(RTSPositionStart, FPSPositionEnd, ratio);
                transform.rotation = Quaternion.Slerp(RTSRotationStart, FPSRotationEnd, ratio);
            }
        }
    }

    private void VisionRTS()
    {

    }
    private void visionTPS()
    {

    }

    private void visionFPS()
    {

    }

    //Create 3PS Vision
    public void Vision()
    {
    }
}
