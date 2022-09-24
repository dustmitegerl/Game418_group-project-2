using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionManager : MonoBehaviourPunCallbacks // extended to use PUN's callbacks
{
    string gameVersion = ".1";

    [SerializeField] // makes variable editable in UnityEditor's inspector
    private byte maxPlayersPerRoom = 5; // room player capacity setting

    // Start is called before the first frame update
    // when game starts,
    void Start()
    {
        // sync scene in the PhotonNetwork and connect the game
        PhotonNetwork.AutomaticallySyncScene = true;
        ConnectGame();
    }

    // when connecting,
    public void ConnectGame()
    {
        // set the gameVersion variable to that used by PhotonNetwork and connect using Photon settings
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    // when connected to master server, 
    public override void OnConnectedToMaster()
    {
        // log the connection to the debugger
        Debug.Log("Connected to master server");

        // and join random room
        PhotonNetwork.JoinRandomRoom();
    }

    // when disconnected, 
    public override void OnDisconnected(DisconnectCause cause)
    {
        // log the disconnection to the debugger
        Debug.Log("Oops! You got disconnected.");
    }

    // if joining a random room doesn't work, 
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // create a new room (with a setting for room's player capacity)
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    // when another player enters the room,
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // say so in the debugger
        Debug.Log("Another player arrived.");
    }

    // when another player leaves, 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // say so in the debugger
        Debug.Log("Another player left.");
    }
}
