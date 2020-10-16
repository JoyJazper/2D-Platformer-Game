using System;
using UnityEngine;
using PlayerPhysics;

namespace LifeMapper{

    public class LivesMap : MonoBehaviour
    {
        public GameObject lifeMarkPrefab;
        public GameController player;
        private GameObject[] playerLives;
        private int lifeLeft;

        void Start()
        {
            playerLives = new GameObject[10];
            lifeLeft = player.GetLife();
            populateLives();
        }

        public void populateLives(){
            GameObject temp;
            for(int i = 1; i <= lifeLeft; i++ ){
                temp = (GameObject)Instantiate(lifeMarkPrefab,transform);
                Debug.Log("Added item number : "+ i);
                playerLives[i] = temp;
            }
        }

        public void DestroyLifeMark(){
            Destroy(playerLives[lifeLeft]);
            lifeLeft--;
        }

        public void AddLifeMark(){
            lifeLeft++;
            GameObject temp;
            temp = (GameObject)Instantiate(lifeMarkPrefab,transform);
            playerLives[lifeLeft] = temp;
        }
    }
}
