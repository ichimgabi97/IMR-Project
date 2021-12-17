using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createInputField;
    public InputField joinInputField;

    private RoomOptions options = new RoomOptions();

    // Start is called before the first frame update
    void Start()
    {
        options.IsVisible = true;
        options.MaxPlayers = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(createInputField.text, options, null);
        Debug.Log("Created");
        Debug.Log(createInputField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputField.text);
	    Debug.Log("Joined");
        Debug.Log(joinInputField.text + ".");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MultiplayerScene");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("Error on logging in");
        Debug.Log(message);
    }
}
