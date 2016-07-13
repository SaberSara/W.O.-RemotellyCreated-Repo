using UnityEngine;
using System.Collections;
using System;

public class Camera_S1 : MonoBehaviour {
    //Déclaration Des Variables De 
    public bool isLerp;
    public Transform FPSPosition;
    public Transform currentCameraPosition;
    public Transform RTSPosition;
    public Transform TPSPosition;
    float speedOfMCamMvmnt = 0.6F;
    public float speed = 1.0F;
    // Use this for initialization
    void Start () {
        //AVoir Le Transform De La Camera Pour La position A Bouger
        FPSPosition = GameObject.Find("_Position_TPS_").GetComponent<Transform>();
        RTSPosition = GameObject.Find("_Position_RTS_").GetComponent<Transform>();
        TPSPosition = GameObject.Find("_Position_TPS_").GetComponent<Transform>();
        currentCameraPosition.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1"))
            VisionRTS();
        // VisionRTS();
        else if (Input.GetButton("Fire2"))
            visionTPS();
        else if (Input.GetButton("Fire3"))
            visionFPS();
	}

    private void VisionRTS()
    {
        //ADD EFfECTS

        /*    currentCameraPosition.position = RTSPosition.position;
            currentCameraPosition.rotation = RTSPosition.rotation; */
        /*float startTime = Time.time;
        float duration = */
        currentCameraPosition.position = transform.position;
        if (currentCameraPosition.position != FPSPosition.position)
            isLerp = true;
        while (isLerp) {
            currentCameraPosition.position = transform.position;
            transform.position = Vector3.Lerp(transform.position, RTSPosition.position, 4 * Time.deltaTime);
                }
        }
        //Debug.Log("RTS");
    

    private void visionTPS()
    {
        //ADD EFfECTS
        currentCameraPosition.position = TPSPosition.position;
        currentCameraPosition.rotation = TPSPosition.rotation;
        Debug.Log("TPS");
    }

    private void visionFPS()
    {
       //ADD EFfECTS
        currentCameraPosition.position = FPSPosition.position;
        currentCameraPosition.rotation = FPSPosition.rotation;
        Debug.Log("FPS");
    }

    //Create 3PS Vision
    public void Vision()
    {

       /*AVoir Le Transform De La Camera Pour La position A Bouger 
        //while (transform.position != endMarker.position)
        //{ 
        //   transform.position=Vector3.Lerp(startMarker.position,endMarker.position,speedOfMCamMvmnt*Time.deltaTime);
        //}
        //transform.position = endMarker.position; */
    }
    //Create 
}
