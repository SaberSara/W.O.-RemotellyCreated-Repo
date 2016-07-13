using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StatusConec : Photon.MonoBehaviour {

    GameObject GUI_Handler;
    bool IsJoined=false;
    AudioSource activate;
    Text Status;
    int roomnumber;
    string _gameVersion = "2.0";
   /* GameObject GUIListRoom =
            Instantiate(Resources.Load("GUI,"),
            new Vector3(5, 5, 5),
            Quaternion.identity) as GameObject;
    private const string roomName = "RoomName";*/
    private RoomInfo[] roomsList;
    // Use this for initialization
    void Start() {
        GUI_Handler = GameObject.Find("GUI_Handler");
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
        Status = GameObject.Find("status").GetComponent<Text>();
        PhotonNetwork.autoJoinLobby = true; ;
        PhotonNetwork.CreateRoom("ImagineCupTry");
        PhotonNetwork.JoinRoom("ImagineCupTry");
        
    


    Debug.Log(PhotonNetwork.connectionStateDetailed);
        //CreateRoom();
    }
    public void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom("Imagine Cup");
        if(PhotonNetwork.connectedAndReady==true)
        Status.text = "Connected To Room : O|o ";
    }
    //void Create_Room()
    /*void CreateRoom()
    {
        if (!PhotonNetwork.connected)
        {

            Status.text = "" + PhotonNetwork.connectionStateDetailed + " ";
        }
        else if (PhotonNetwork.room == null)
        {
            // Create Room

            PhotonNetwork.CreateRoom("room 1");
            roomsList = PhotonNetwork.GetRoomList();
            SceneManager.LoadScene(1);
        }


    }*/


    // Update is called once per frame
    void Update() {
        Status.text = "Statu :" + PhotonNetwork.connectionStateDetailed + "Connected To Room : " +PhotonNetwork.room.name;
        //Status.text = "Statu :" + PhotonNetwork.connectionStateDetailed
    }
    
    void OnFailedJoin()
    {

    }  
    //C();
   /* public void C()
    {
         if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                    GameObject List =Instantiate(Resources.Load("GUI,"), new Vector3(15+i, i+5, 0),
            Quaternion.identity) as GameObject;
                        
                }
            }
    }
    //void Create_Room()
    void CreateRoom()
    {
        if (!PhotonNetwork.connected)
        {

            Status.text = "" + PhotonNetwork.connectionStateDetailed + " ";
        }
        else if (PhotonNetwork.room == null)
        {
            // Create Room

            PhotonNetwork.CreateRoom("room 1");
            roomsList = PhotonNetwork.GetRoomList();
            SceneManager.LoadScene(1);
        }
            
        
    }
    // Join Room 
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("room 1");
        SceneManager.LoadScene(2);
    }
    void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();

    }
    /*
    void Update()
{
    if (photonView.isMine)
    {
        InputMovement();
        InputColorChange();
    }
    else
    {
        SyncedMovement();
    }
}
 
private void InputColorChange()
{
    if (Input.GetKeyDown(KeyCode.R))
        ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
}
 
[RPC] void ChangeColorTo(Vector3 color)
{
    renderer.material.color = new Color(color.x, color.y, color.z, 1f);
 
    if (photonView.isMine)
        photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
}
*/
    void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
    }

    
}
   