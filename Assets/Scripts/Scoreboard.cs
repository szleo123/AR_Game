using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class Scoreboard : MonoBehaviour
    {
        private Dictionary<string, int> scores; 
        private Dictionary<string, int> shields;
        private bool ended = false; 
        // Start is called before the first frame update
        private void Start()
        {
            this.scores = new Dictionary<string, int>();
            this.shields = new Dictionary<string, int>(); 
        }

        // Update is called once per frame
        void Update(){}

        public void reset()
        {
            this.scores.Clear(); 
            this.shields.Clear();
            ended = false; 
        }

        public void setScore(string playerName, int score)
        {
            if (this.scores.ContainsKey(playerName))
            {
                this.scores[playerName] = score;
            }else
            {
                this.scores.Add(playerName, score);
            }
        }

        public int getScore(string playerName)
        {
            if (this.scores.ContainsKey(playerName))
            {
                return this.scores[playerName];
            }else
            {
                return 0;
            }
        }

        public void setShield(string playerName, int shield)
        {
            if (this.shields.ContainsKey(playerName))
            {
                this.shields[playerName] = shield;
            }else
            {
                this.shields.Add(playerName, shield);
            }
        }

        public int getShield(string playerName)
        {
            if (this.shields.ContainsKey(playerName))
            {
                return this.shields[playerName];
            }else
            {
                return 0;
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            foreach(var score in this.scores)
            {
                if (score.Value >= 5)
                {
                    ended = true;
                }
            }
            if (!ended)
            {
                foreach (var score in this.scores)
                {
                    GUILayout.Label($"{score.Key}: {score.Value}", new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
                }
                foreach (var s in this.shields)
                {
                    GUILayout.Label($"{s.Key}: shield {s.Value}", new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
                }
            } else
            {
                foreach(var score in this.scores)
                {
                    if (score.Value >= 5){
                        GUILayout.Label($"{score.Key}: You win!", new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
                    } else {
                        GUILayout.Label($"{score.Key}: You lose!", new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
                    }
                }
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
