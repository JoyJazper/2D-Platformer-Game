using UnityEngine;
using PlayerPhysics;
namespace Enemy{

    
    public class DumbEnemy : Enemy
    {   
        private void Start() {
            hitPoint = 250;
            enemyA = gameObject.GetComponent<Animator>();
            enemyA.SetBool("IsIdle", true);
        }
    }
}

