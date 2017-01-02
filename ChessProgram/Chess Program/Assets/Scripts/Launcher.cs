using UnityEngine;

namespace Com.RedObject.ChessDemo
{
    public class Launcher : Photon.PunBehaviour
    {
        #region Public Variables

        #endregion

        #region Private Varibles
        private string _gameVersion = "1";

        #endregion

        #region MonoBehaviour CallBacks
        private void Awake()
        {
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = true;
        }

        private void Start()
        {
            Connect();
        }

        #endregion

        #region Public Methods
        public void Connect()
        {
            if (PhotonNetwork.connected)
            {
                PhotonNetwork.JoinRandomRoom();
            }

            else
            {
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
            }
        }
        #endregion

        #region Photon.PunBehaviour CallBacks


        public override void OnConnectedToMaster()
        {
            Debug.Log("Launcher: OnConnectedToMaster() was called by PUN");
            PhotonNetwork.JoinRandomRoom();

        }

        public override void OnDisconnectedFromPhoton()
        {
            Debug.LogWarning("Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, null);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }

        #endregion

    }
}