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
        protected override void LateUpdate() {

        }
    }
}

