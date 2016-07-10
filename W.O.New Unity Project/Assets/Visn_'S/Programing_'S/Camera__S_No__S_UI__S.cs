using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Camera__S_No__S_UI__S : MonoBehaviour {

    //Butt
    Button TPSBut;
    GameObject TPSButGO,RTSButGO,FPSButGO;
    Vector3 camPos, RTSPos, TPSPos, FPSPos;
    Quaternion camRot, FPSRot,TPSRot,RTSRot;
    [SerializeField] float driftSeconds = 3;
    private float driftTimer;
    private bool isDriftingToFPS=false,isDriftingToTPS=false,isDriftingToRTS=false;

	// Use this for initialization
	void Start () {






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
	void Update () {

        //RTS


        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKey(KeyCode.Keypad0) || (EventSystem.current.currentSelectedGameObject == FPSButGO))
            {
            isDriftingToRTS = false;
            isDriftingToFPS = true;
            isDriftingToTPS = false;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;
            }
        else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1) || (EventSystem.current.currentSelectedGameObject == TPSButGO))
        {
            
            isDriftingToRTS = false;
            isDriftingToFPS = false;
            isDriftingToTPS = true;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;
        }
        else if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2) || (EventSystem.current.currentSelectedGameObject == RTSButGO))
        {

            isDriftingToRTS = true;
            isDriftingToFPS = false;
            isDriftingToTPS = false;
            driftTimer = 0;

            camPos = transform.position;
            camRot = transform.rotation;
        }
        if (isDriftingToFPS)
        {
            driftTimer = driftTimer + Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                isDriftingToFPS = false;
                transform.position = FPSPos;
                transform.rotation = FPSRot;
            }
            else
            {
                float ratio = driftTimer / driftSeconds;
                transform.position = Vector3.Lerp(camPos, FPSPos, ratio);
                transform.rotation = Quaternion.Slerp(camRot, FPSRot, ratio);
            }
        }
        if (isDriftingToTPS)
        {
            driftTimer = driftTimer + Time.deltaTime;
            if (driftTimer > driftSeconds)
            {
                isDriftingToTPS = false;
                transform.position = TPSPos;
                transform.rotation = TPSRot;
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
            driftTimer = driftTimer + Time.deltaTime;
            if(driftTimer > driftSeconds)
            {
                isDriftingToRTS = false;
                transform.position = RTSPos;
                transform.rotation = RTSRot;
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
