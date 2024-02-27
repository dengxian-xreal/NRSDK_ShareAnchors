using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class JoinRoomButton : MonoBehaviourPunCallbacks
{
    public Button joinedRoomIndicator;

    public void OnButtonClick()
    {
        // Connect to the Photon master server
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            TryJoinRoom();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon master server");
        TryJoinRoom();
    }

    private void TryJoinRoom()
    {
        // Try to join the room "MyRoom"
        PhotonNetwork.JoinRoom("MyRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        // joinedRoomIndicator.SetActive(true);
        joinedRoomIndicator.image.color = Color.green;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
        // If we failed to join the room, it might not exist, so let's try to create it
        PhotonNetwork.CreateRoom("MyRoom");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room");
    }
}
