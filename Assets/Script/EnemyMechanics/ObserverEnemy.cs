using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPhysics;

namespace Enemy{
    public class ObserverEnemy : Enemy
    {
        private void Start() {
            hitPoint = 500;
            enemyA = GetComponent<Animator>();
        }
    }

}
