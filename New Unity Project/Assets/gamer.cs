using UnityEngine;
using System.Collections;

public class gamer : MonoBehaviour {
    Transform camera;
	// Use this for initialization
	void Start () {
        //camera = GameObject.Find("Main_Camera").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Input.GetAxis("Mouse X") * 11, Input.GetAxis("Mouse Y"),  0f));


    }
}
