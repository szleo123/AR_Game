namespace MyFirstARGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Photon.Pun; 
    

    public class PlayerBodyScript : MonoBehaviourPunCallbacks
    {
        public Camera playerCamera; 
        // Start is called before the first frame update
        void Start()
        {
            playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); 
            if (photonView.IsMine){
                // Follow the camera's position
                Vector3 cameraPos = playerCamera.transform.position; 
                transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z); 

                // Follow the camera's direciton 
                transform.rotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0); 
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine){
                // Follow the camera's position
                Vector3 cameraPos = playerCamera.transform.position; 
                transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z); 

                // Follow the camera's direciton 
                transform.rotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0); 

            }
        }

        void OncollisionEnter(Collision collision){
            Collider collider = collision.collider; 
            if (collider.CompareTag("Bullet")){
                Debug.Log("Handle collision"); 
            }
        }
    }
}
