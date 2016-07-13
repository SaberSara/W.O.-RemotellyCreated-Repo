using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtonsClick : MonoBehaviour {

    GameObject GUI_Handler;
    GameObject GUI1;
    Text Gui_build;
    AudioSource activate;

    



	void Start () {
        GUI_Handler = GameObject.Find("GUI_Handler");
        GUI1 = GameObject.Find("Plonge");
        Gui_build = GUI1.GetComponent<Text>();
        Debug.Log("get Componen");
        activate = GUI1.GetComponent<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () {
        Gui_build.text = " :) ";
        
        
	}

    public void build()
    {
        SceneManager.LoadScene(1);
        activate.Play();
        Gui_build.text = " :) ";

    }
}
