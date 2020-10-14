using UnityEngine;
using PlayerPhysics;
namespace Enemy{

    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public class DumbEnemy : Enemy
    {
        private Animator EnemyA;

        private void Start() {
            hitPoint = 500;
            active = true;
            speed = 0;
            EnemyA = gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            EnemyA.Play("Enemy1Attack");
            if(other.gameObject.GetComponent<PlayerController>() != null){
                other.gameObject.GetComponent<PlayerController>().SetHealth(-hitPoint);
            }
        }
    }
}

