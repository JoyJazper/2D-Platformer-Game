using UnityEngine;

namespace Enemy{
    public class ObserverEnemy : Enemy
    {
        private void Start() {
            hitPoint = 500;
            enemyA = GetComponent<Animator>();
        }
    }
}
