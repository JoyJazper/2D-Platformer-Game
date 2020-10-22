using UnityEngine;
using PlayerPhysics;
namespace Enemy{
    public class SmartEnemy : Enemy
    {
        private void Start() {
            hitPoint = 250;
            enemyA = GetComponent<Animator>();
            enemyA.Play("Enemy1Walk");
        }

        protected override void AttackPlayer(Collider2D other) {
            if(other.gameObject.GetComponent<PlayerController>() != null){
                enemyA.Play("Enemy1Attack");
                other.gameObject.GetComponent<PlayerController>().SetHealth(-hitPoint);
                enemyA.SetBool("Walker", true);
                playerPushAway();
            }
        }

        protected override void LookAtPlayer() {
            //Intended to override with empty...
        }
    }
}

