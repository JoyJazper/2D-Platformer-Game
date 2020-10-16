using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffTrigger : MonoBehaviour
{
    private SmartEMovement enemy;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<SmartEMovement>() != null){
            enemy = other.gameObject.GetComponent<SmartEMovement>();
            enemy.CliffNoticed();
        }
    }
}
