using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class DumbHard : MonoBehaviour
{
    private bool isVisible = false;
    public Transform playerTransform;

    private Animator enemyA;
    private float speed;
    Vector3 playerPos;

    Vector3 selfpos;

    private void Start() {
        speed = 10.0f;
        enemyA = gameObject.GetComponentInChildren<Animator>();
        playerPos.y = transform.position.y;
        playerPos.z = transform.position.z;
    }

    void Update()
    {
        // Vector3 dir = playerTransform.position - transform.position;
        // float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        if(isVisible)
        {
            float step =  speed * Time.deltaTime;
            playerPos.y = transform.position.y;
            playerPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
            if (Vector3.Distance(transform.position, playerPos) < 0.001f)
            {
                isVisible = false;
                Debug.Log("Is visible off.");
            }
        }
    }

    public void OnPlayerVisible(Transform player){
        enemyA.SetBool("IsVisible",true);
        isVisible = true;
        playerPos.x = player.position.x;
    }

    public void OnPlayerNotVisible(){
        enemyA.SetBool("IsVisible",false);
        isVisible = false;
    }
}
