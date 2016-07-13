using UnityEngine;
using System.Collections;

public class Camera__S_FPS_No__S_UI__S : MonoBehaviour {

    public static Transform FPSActualPositionCam;
    private Transform target;
    private Transform FPSTransPos;
    [SerializeField]
    private float minX = -360.0f;
    [SerializeField]
    private float maxX = 360.0f;

    [SerializeField]
    private float minY = -45.0f;
    [SerializeField]
    private float maxY = 45.0f;

    [SerializeField]
    private float sensX = 100.0f;
    [SerializeField]
    private float sensY = 100.0f;

    [SerializeField]
    private float rotationY = 0.0f;
    [SerializeField]
    private float rotationX = 0.0f;
    // Use this for initialization
    void Start () {



        FPSActualPositionCam = GameObject.Find("FrstPSCVision_'S ").GetComponent<Transform>();
        FPSTransPos = GameObject.Find("FrstPSCVision_'S ").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Camera__S_No__S_UI__S.FPSIsOK)
        {

            //FPSTransPos.LookAt(target);
            //transform.rotation = FPSTransPos.rotation * target.rotation;
            transform.position = FPSTransPos.position;
            transform.rotation = FPSTransPos.rotation;
            //transform.rotation = FPSTransPos.rotation*target.rotation;
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

            FPSActualPositionCam.position = transform.position;
            FPSActualPositionCam.rotation = transform.rotation;
        }
    }
    
}
