using UnityEngine;
using System.Collections;

public class Basic__S_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

















        



        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*5, 0.0f, Input.GetAxis("Vertical")*5));
	}
}
