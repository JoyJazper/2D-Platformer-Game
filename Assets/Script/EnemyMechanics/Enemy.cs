
using UnityEngine;
using PlayerPhysics;

namespace Enemy{
    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public abstract class Enemy : MonoBehaviour
    {
        protected int hitPoint;
        protected float speed;
        protected bool active;

        public Transform playerTransform;
        protected Animator enemyA;

        private Vector3 targetPos;
        private Vector3 thisPos;



        protected void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.GetComponent<PlayerController>() != null){
                enemyA.Play("Enemy1Attack");
                other.gameObject.GetComponent<PlayerController>().SetHealth(-hitPoint);
            }
        }

        protected virtual void LateUpdate() {

            targetPos = playerTransform.position;
            thisPos = transform.position;
            if(thisPos.x > targetPos.x){
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }else{
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }
}

