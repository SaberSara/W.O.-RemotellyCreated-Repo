using UnityEngine;
using System.Collections;

public class Camera__S_TPS_No__S_UI__S : MonoBehaviour
{



    public static Transform TPSActualPositionCam;
    private Transform TPSTransPos;
    private Transform target;
    [SerializeField]
    private float distance = 5.0f;
    [SerializeField]
    private float xSpeed = 120.0f;
    [SerializeField]
    private float ySpeed = 120.0f;

    [SerializeField]
    private float yMinLimit = -20f;
    [SerializeField]
    private float yMaxLimit = 80f;

    [SerializeField]
    private float distanceMin = .5f;
    [SerializeField]
    private float distanceMax = 15f;

    float x = 0.0f;
    float y = 0.0f;



    // Use this for initialization
    void Start()
    {
        TPSActualPositionCam = GameObject.Find("TrdPSCVision_'S").GetComponent<Transform>();
        TPSTransPos = GameObject.Find("TrdPSCVision_'S").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime);
        //transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse Y") * Time.deltaTime);
    }







    void LateUpdate()
    {
        if (target && Camera__S_No__S_UI__S.TPSIsOK)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

            TPSActualPositionCam.position = transform.position;
            TPSActualPositionCam.rotation = transform.rotation;
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    } 
}
