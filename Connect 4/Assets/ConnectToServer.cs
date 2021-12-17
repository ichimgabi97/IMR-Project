using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        TypedLobby typed = new TypedLobby("Connect4", LobbyType.Default);
        PhotonNetwork.JoinLobby(typed);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log(PhotonNetwork.CloudRegion);
        SceneManager.LoadScene("MultiplayerJoin");
        PhotonNetwork.AutomaticallySyncScene = false;
    }
}
