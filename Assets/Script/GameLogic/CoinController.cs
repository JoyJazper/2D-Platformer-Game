using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayerPhysics;
public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.PickUpCoin();
            Destroy(gameObject);
        }
    }
}
