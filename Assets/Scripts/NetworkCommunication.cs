namespace MyFirstARGame
{
    using Photon.Pun;
    using UnityEngine;
    
    /// <summary>
    /// You can use this class to make RPC calls between the clients. It is already spawned on each client with networking capabilities.
    /// </summary>
    public class NetworkCommunication : MonoBehaviourPun
    {
        [SerializeField]
        private Scoreboard scoreboard; 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void IncrementScore()
        {
            var playerName = $"Player {PhotonNetwork.LocalPlayer.ActorNumber}"; 
            var currentScore = this.scoreboard.getScore(playerName);
            this.photonView.RPC("Network_SetPlayerScore", RpcTarget.All, playerName, currentScore + 1); 
        }

        public int getScore()
        {
            var playerName = $"Player {PhotonNetwork.LocalPlayer.ActorNumber}"; 
            var currentScore = this.scoreboard.getScore(playerName);
            return currentScore;
        }

        public void DecrementShield()
        {
            string playerName;
            if (PhotonNetwork.LocalPlayer.ActorNumber > 1){
                playerName = $"Player 1"; 
            } else {
                playerName = $"Player 2"; 
            }
            
            var currentShield = this.scoreboard.getShield(playerName);
            this.photonView.RPC("Network_SetPlayerShield", RpcTarget.All, playerName, currentShield + 1);
        }

        public int getShield()
        {
            string playerName;
            if (PhotonNetwork.LocalPlayer.ActorNumber > 1){
                playerName = $"Player 2"; 
            } else {
                playerName = $"Player 1"; 
            }
            var currentShield = this.scoreboard.getShield(playerName);
            return currentShield;
        }

        [PunRPC]
        public void Network_SetPlayerScore(string playerName, int score)
        {
            Debug.Log($"Player {playerName} scored!"); 
            this.scoreboard.setScore(playerName, score);
        }

        [PunRPC]
        public void Network_SetPlayerShield(string playerName, int shield)
        {
            this.scoreboard.setShield(playerName, shield);
        }

        public void UpdateForNewPlayer(Photon.Realtime.Player player)
        {
            var playerName = $"Player {PhotonNetwork.LocalPlayer.ActorNumber}";
            var currentScore = this.scoreboard.getScore(playerName);
            var currentShield = this.scoreboard.getShield(playerName); 
            this.photonView.RPC("Network_SetPlayerScore", player, playerName, currentScore);
            this.photonView.RPC("Network_SetPlayerShield", player, playerName, currentShield);
        }
    }

}