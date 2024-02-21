using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class PlayerInfo :  MonoBehaviourPunCallbacks
    {
        public float shootInterval = 1.0f; 
        public float curTime = 0; 
        public int shieldCount = 5; 
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            curTime += Time.deltaTime; 
        }
    }
}
