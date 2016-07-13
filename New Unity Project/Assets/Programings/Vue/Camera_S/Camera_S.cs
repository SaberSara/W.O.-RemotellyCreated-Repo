using UnityEngine;
using System.Collections;

public class Camera_S : MonoBehaviour {
    //Déclaration Des Variables De 

    public Transform startMarker;
    public Transform endMarker;
    float speedOfMCamMvmnt = 0.6F;
    public float speed = 1.0F;
    // Use this for initialization
    void Start () {
        //AVoir Le Transform De La Camera Pour La position A Bouger
        endMarker.position = GameObject.Find("_Position_TPS").GetComponent<Transform>().position;
        startMarker.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1"))
          Vision();
	}

    //Create 3PS Vision
    public void Vision()
    {

        //AVoir Le Transform De La Camera Pour La position A Bouger 
        //while (transform.position != endMarker.position)
        //{ 
           transform.position=Vector3.Lerp(startMarker.position,endMarker.position,speedOfMCamMvmnt*Time.deltaTime);
        //}
        //transform.position = endMarker.position;
    }
    //Create 
}
