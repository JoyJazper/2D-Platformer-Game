using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPhysics;

[RequireComponent(typeof(BoxCollider2D))]
public class ObserveBehavior : MonoBehaviour
{
    private DumbHard enemy;
    private Transform player;

    private void Start() {
        enemy = GetComponentInParent<DumbHard>();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            player = other.GetComponent<Transform>();
            enemy.OnPlayerVisible(player);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        enemy.OnPlayerNotVisible();
    }
}
