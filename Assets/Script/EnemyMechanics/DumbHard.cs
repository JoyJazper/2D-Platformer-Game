
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DumbHard : MonoBehaviour
{
    public Transform playerTransform;
    private Animator enemyA;
    private float speed;
    private float step;
    private Vector3 enemyPos;
    private float distance;

    private void Start() {
        speed = 10.0f;
        enemyA = gameObject.GetComponentInChildren<Animator>();
        enemyPos = transform.position;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance < 25.0f){
            OnPlayerVisible();
        }else{
            OnPlayerNotVisible();
        }
    }

    private void OnPlayerVisible(){
        enemyA.Play("Enemy1Run");
        enemyPos.x = playerTransform.position.x;
        step =  speed * Time.deltaTime;
        enemyPos.y = transform.position.y;
        enemyPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, enemyPos, step);
    }

    private void OnPlayerNotVisible(){
        enemyA.Play("Enemy1Idle");
    }
}
