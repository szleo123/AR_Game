namespace MyFirstARGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Photon.Pun; 
    

    public class ShieldScript: MonoBehaviourPunCallbacks
    {
        public Camera playerCamera; 

        public float shieldDistance = 0.3f; 
        // Start is called before the first frame update
        void Start()
        {
            playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); 
            if (photonView.IsMine){
                // Follow the camera's position
                Vector3 cameraPos = playerCamera.transform.position; 
                transform.position = cameraPos + playerCamera.transform.forward * shieldDistance; 

                // Follow the camera's direciton 
                transform.rotation = playerCamera.transform.rotation; 
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine){
                // Follow the camera's position
                Vector3 cameraPos = playerCamera.transform.position; 
                transform.position = cameraPos + playerCamera.transform.forward * shieldDistance; 

                // Follow the camera's direciton 
                transform.rotation = playerCamera.transform.rotation; 

            }
        }

        void OnCollisionEnter(Collision collision){
            Collider collider = collision.collider; 
            PhotonView colPhotonView = collider.gameObject.GetComponent<PhotonView>(); 
            if (collider.CompareTag("Bullet")){
                // Update the score 
                var networkCommunication = FindObjectOfType<NetworkCommunication>(); 
                networkCommunication.DecrementShield();
            }
        }
    }
}
