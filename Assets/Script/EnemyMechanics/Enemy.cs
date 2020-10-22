
using UnityEngine;
using PlayerPhysics;

namespace Enemy{
    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public abstract class Enemy : MonoBehaviour
    {
        protected int hitPoint;
        public Transform playerTransform;
        protected Animator enemyA;
        private Vector3 targetPos;
        private Vector3 thisPos;

        protected void OnTriggerEnter2D(Collider2D other) {
            AttackPlayer(other);
        }
        
        protected virtual void AttackPlayer(Collider2D other){
            if(other.gameObject.GetComponent<PlayerController>() != null){
                enemyA.Play("Enemy1Attack");
                other.gameObject.GetComponent<PlayerController>().SetHealth(-hitPoint);
                playerPushAway();
            }
        }
        protected Vector3 axisValues;
        protected float displacementValue = 5.0f;
        protected void playerPushAway(){
            if(playerTransform.localScale.x < 0){
                    axisValues.x = playerTransform.position.x;
                    axisValues.y = playerTransform.position.y;
                    axisValues.z = playerTransform.position.z;
                    axisValues.x += displacementValue;
                    playerTransform.position = axisValues;
                    Debug.Log("Force Added to right");
                }else{
                    axisValues.x = playerTransform.position.x;
                    axisValues.y = playerTransform.position.y;
                    axisValues.z = playerTransform.position.z;
                    axisValues.x -= displacementValue;
                    playerTransform.position = axisValues;
                    Debug.Log("Force Added to Left");
                }
        }

        protected void LateUpdate() {
            LookAtPlayer();
        }

        protected virtual void LookAtPlayer(){
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

