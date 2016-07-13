using UnityEngine;
using System.Collections;

public class Camera__S_RTS_No__S_UI__S : MonoBehaviour
{
    public static Transform RTSActualPositionCam;

    private Transform target;
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;









    private float actualZoom;

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
    private float mouseX;
     private float mouseZ;
    private Vector3 camPos;
    private GameObject camPosGO;
    [SerializeField]
    private float mouseSpeed = 5.1f;
    [SerializeField]        private float ratio=0.01f;
    [SerializeField] private float mouseZoom = 5.1f;
    [SerializeField]        private float maxZoom=5.1f;
    
    // Use this for initialization
    void Start () {
           target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
           RTSActualPositionCam = GameObject.Find("RaelTSCVision_'S ").GetComponent<Transform>();
           camPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
           camPosGO = GameObject.FindGameObjectWithTag("MainCamera");
           mouseX = 0;
           mouseZ = 0;
        
    }

       // Update is called once per frame
       void Update () {
        if(Camera__S_No__S_UI__S.RTSIsOK)
        {
            //Zoom The Camera
            /* transform.Translate(0, Input.GetAxis("Mouse ScrollWheel") * mouseZoom * Time.smoothDeltaTime, Input.GetAxis("Mouse ScrollWheel") * mouseZoom * Time.smoothDeltaTime, Space.World);
            if(Input.GetAxis("Mouse ScrollWheel")>maxZoom )
                transform.Translate(0,  maxZoom, Input.GetAxis("Mouse ScrollWheel") * maxZoom, Space.World);
            else if(Input.GetAxis("Mouse ScrollWheel") < -5.1)
                 transform.Translate(0,- maxZoom, Input.GetAxis("Mouse ScrollWheel") * maxZoom, Space.World);
            else*/
            /* transform.Translate(0f, 0f ,  Mathf.Clamp(Input.GetAxis("Mouse ScrollWheel"), -maxZoom, maxZoom) , Space.Self); */
            //Zoom The Camera
            
        transform.Translate(0f, 0f ,  -Time.smoothDeltaTime*Mathf.Clamp(Input.GetAxis("Mouse ScrollWheel")*mouseSpeed, -maxZoom, maxZoom) , Space.Self);

            //save Information On The Current Position Of The Player And The Position In Camera The  - ZOOM SAVE Information To Restart in The Back Click At The same Zoom - LITTLE BIT TESTED - INTEGRATED BUT NOT WELL WOTKED AND REMOVED UNTIL NEXT IF NECES HAVE ON AFTER BRO'S TESTING_'S      
            actualZoom = -Time.smoothDeltaTime * Mathf.Clamp(Input.GetAxis("Mouse ScrollWheel") * mouseSpeed, -maxZoom, maxZoom);

        //Rotate Te Camera   
            if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.smoothDeltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.smoothDeltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
       //Move the Camera On X And Y 
            if(Input.GetMouseButton(2))
            {
                

                transform.position += new Vector3(-Input.GetAxis("Mouse X") * mouseSpeed * Time.smoothDeltaTime, 0,
                                        -Input.GetAxis("Mouse Y") * mouseSpeed * Time.smoothDeltaTime);
            /*
            RTSActualPositionCam.position = new Vector3(target.position.x, 500f, target.position.z);
            */
            
                //new Vector3(Input.mousePosition.x* Time.deltaTime*1, 0, Input.mousePosition.z * Time.deltaTime * 1);

            }
        //   var pan = camPos.transform.eulerAngles.x - 5 * 1;
        //   pan = Mathf.Clamp(pan, 10, 20);

            //save Information On The Current Position Of The Player And The Position In Camera The 
        RTSActualPositionCam.position = new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, target.transform.position.z - zOffset); 
        RTSActualPositionCam.rotation = transform.rotation ;

       /*
        RTSActualPositionCam.position=transform.position;
            RTSActualPositionCam.rotation = transform.rotation;
            */
            //Move Camera when mouse is  in the edge
            //Met1
            /*if (Input.mousePosition.x > Screen.width - 0)
            {
                transform.localEulerAngles = new Vector3(transform.position.x+ 100 * Time.deltaTime, rotationX, 0);
               
            }*/
            //Met2
            /*Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0.0) Debug.Log("I am left of the camera's view.");*/
        }

    }
    /*void LateUpdate()
    {
        if(Input.anyKey)
        this.transform.position = new Vector3(target.transform.position.x + xOffset,
                                              target.transform.position.y + yOffset,
                                              target.transform.position.z + zOffset);
    }*/
}
