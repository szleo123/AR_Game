namespace MyFirstARGame
{
    using UnityEngine;
    using System.Collections; 
    using System.Collections.Generic; 
    using Photon.Pun;

    /// <summary>
    /// Launches shield from a touch point.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class Launcher : PressInputBase
    {
        [SerializeField]
        private GameObject shieldPrefab;

        protected override void OnPressBegan(Vector3 position)
        {
            if (this.shieldPrefab == null || !NetworkLauncher.Singleton.HasJoinedRoom)
                return;

            // Ensure user is not doing anything else.
            var uiButtons = FindObjectOfType<UIButtons>();
            if (uiButtons != null && (uiButtons.IsPointOverUI(position) || !uiButtons.isShielding))
                return;

            // We send our current player number as data so that the projectile can pick its material based on the player that owns it.
            var initialData = new object[] { PhotonNetwork.LocalPlayer.ActorNumber };
            
            PlayerInfo playerinfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>(); 
            if (playerinfo.shieldCount > 0)
            {
                var shield = PhotonNetwork.Instantiate(this.shieldPrefab.name, Vector3.zero, Quaternion.identity, data: initialData); 
            }
        }     

        protected override void OnPress(Vector3 position)
        {

        }

        protected override void OnPressCancel()
        {

        }
    }
}
