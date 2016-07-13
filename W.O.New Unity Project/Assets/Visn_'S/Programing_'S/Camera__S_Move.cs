using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Camera__S_Move : MonoBehaviour {

    //Butt
    Button TPSBut;
    GameObject TPSButGO, RTSButGO, FPSButGO;
    Vector3 camPos, RTSPos, TPSPos, FPSPos;
    Quaternion camRot, FPSRot, TPSRot, RTSRot;
    [SerializeField]
    float driftSeconds = 3;
    private float driftTimer;
    private bool isDriftingToFPS = false, isDriftingToTPS = false, isDriftingToRTS = false;
    private GameObject tripleVisionScript;


    public static bool RTSIsOK = false, FPSIsOK=false,TPSIsOK=false;
    // Use this for initialization
    void Start()
    {

        tripleVisionScript = GameObject.Find("Main Camera");




        //Butt

        //TPSBut = GameObject.Find("TPS").GetComponent<Button>();
        TPSButGO = GameObject.Find("TPS");
        RTSButGO = GameObject.Find("RTS");
        FPSButGO = GameObject.Find("FPS");

        camPos = transform.position;
        camRot = transform.rotation;
        FPSPos = GameObject.Find("FrstPSCVision_'S ").transform.position;

        RTSPos = GameObject.Find("RaelTSCVision_'S ").transform.position;

        TPSPos = GameObject.Find("TrdPSCVision_'S").transform.position;

        TPSRot = GameObject.Find("TrdPSCVision_'S").transform.rotation;
        RTSRot = GameObject.Find("RaelTSCVision_'S ").transform.rotation;
        FPSRot = GameObject.Find("FrstPSCVision_'S ").transform.rotation;

    }



    // Update is called once per frame
    void Update()
    {

       
            transform.position = RTSPos;
            transform.rotation = RTSRot;
        /*
        if (TPSIsOK)
        {
            transform.position = TPSPos;
            transform.rotation = TPSRot;
        }
        if (FPSIsOK)
        {
            transform.position = FPSPos;
            transform.rotation = FPSRot;
        }*/















        //FPS Input Clivk


        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKey(KeyCode.Keypad0) || (EventSystem.current.currentSelectedGameObject == FPSButGO))
        {
            //Compovents Vivion Camera for Player Special Camera Interaction Activating / Descativating Switch Of The Case Of Vison Camera
            /*tripleVisionScript.GetComponent<Camera__S_RTS_No__S_UI__S>().enabled = false;
            tripleVisionScript.GetComponent<Camera__S_FPS_No__S_UI__S>().enabled = true;
            tripleVisionScript.GetComponent<Camera__S_TPS_No__S_UI__S>().enabled = false;*/

            //Initialising Processus And Somes Important To initialize First Values For The Next Beside Process Of Lerping Vivion Camera
            isDriftingToRTS = false;
            isDriftingToFPS = true;
            isDriftingToTPS = false;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;
        }

        //TPS Input Clivk


        else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1) || (EventSystem.current.currentSelectedGameObject == TPSButGO))
        {
            //Compovents Vivion Camera for Player Special Camera Interaction Activating / Descativating Switch Of The Case Of Vison Camera
            /*tripleVisionScript.GetComponent<Camera__S_RTS_No__S_UI__S>().enabled = false;
            tripleVisionScript.GetComponent<Camera__S_FPS_No__S_UI__S>().enabled = false;

            tripleVisionScript.GetComponent<Camera__S_TPS_No__S_UI__S>().enabled = true;*/

            //Initialising Processus And Somes Important To initialize First Values For The Next Beside Process Of Lerping Vivion Camera
            isDriftingToRTS = false;
            isDriftingToFPS = false;
            isDriftingToTPS = true;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;

        }

        //RTS Input Clivk


        else if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2) || (EventSystem.current.currentSelectedGameObject == RTSButGO))
        {
            //Compovents Vivion Camera for Player Special Camera Interaction Activating / Descativating Switch Of The Case Of Vison Camera
            /*tripleVisionScript.GetComponent<Camera__S_RTS_No__S_UI__S>().enabled = true;
            tripleVisionScript.GetComponent<Camera__S_FPS_No__S_UI__S>().enabled = false;
            tripleVisionScript.GetComponent<Camera__S_TPS_No__S_UI__S>().enabled = false;*/

            //Initialising Processus And Somes Important To initialize First Values For The Next Beside Process Of Lerping Vivion Camera
            isDriftingToRTS = true;
            isDriftingToFPS = false;
            isDriftingToTPS = false;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;
        }

        //FPS Vivion Camera Click 

        if (isDriftingToFPS)
        {

            //Lerping Vivion Camera
            driftTimer = driftTimer + Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                isDriftingToFPS = false;
                transform.position = FPSPos;
                transform.rotation = FPSRot;
                FPSIsOK = true;
                RTSIsOK = false;
                TPSIsOK = false;
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(camPos, FPSPos, ratio);
                transform.rotation = Quaternion.Slerp(camRot, FPSRot, ratio);
            }
        }
        //TPS Vivion Camera Click 
        if (isDriftingToTPS)
        {
            //Lerping Vivion Camera
            driftTimer = driftTimer + Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                isDriftingToTPS = false;
                transform.position = TPSPos;
                transform.rotation = TPSRot;
                FPSIsOK = false;
                RTSIsOK = false;
                TPSIsOK = true;
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(camPos, TPSPos, ratio);
                transform.rotation = Quaternion.Slerp(camRot, TPSRot, ratio);
            }
        }
        if (isDriftingToRTS)
        {
            //Lerping Vivion Camera
            driftTimer = driftTimer + Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                isDriftingToRTS = false;
                transform.position = RTSPos;
                transform.rotation = RTSRot;
                FPSIsOK = false;
                RTSIsOK = true;
                TPSIsOK = false;
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(camPos, RTSPos, ratio);
                transform.rotation = Quaternion.Slerp(camRot, RTSRot, ratio);
            }
        }



    }
}
