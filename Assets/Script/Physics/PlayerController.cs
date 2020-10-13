using System;
using UnityEngine;

namespace PlayerPhysics
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        private Animator playerAnimator;
        private Rigidbody2D playerRigidbody;
        private BoxCollider2D playerCollider;
        private float horizontal;
        private float vertical;
        private Vector3 scale;
        private Vector3 position;

        // IsGrounded - Svariables
        public LayerMask ground;
        private Vector2 playerColliderBounds;
        private Vector2 playerColliderSize;

        public float speed;
        public float jumpForce;
        public float heightToGround;

        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<BoxCollider2D>();
            scale = transform.localScale;
        }

        private void Update()
        {
            GetInput();
            RunCheck();
            JumpCheck();
            CouchCheck();
            MovePlayerHorizontal(horizontal);
        }

        private void MovePlayerVertical()
        {
            playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            Debug.Log("Did it");
        }

        private void MovePlayerHorizontal(float tempHorizontal)
        {
            if(!playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Couch")){
                position = transform.position;
                position.x += tempHorizontal * speed * Time.deltaTime;
                transform.position = position;
            }
        }

        private void GetInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Jump");
        }
        private void RunCheck()
        {
            playerAnimator.SetFloat("speed", Mathf.Abs(horizontal));
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        private void JumpCheck()
        {
            if (vertical > 0)
            {
                if (IsGrounded() && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
                {
                    MovePlayerVertical();
                    playerAnimator.Play("Jump");
                }
            }
        }

        private void CouchCheck()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerAnimator.Play("Couch");
                playerAnimator.SetBool("couchB", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                playerAnimator.SetBool("couchB", false);
            }
        }

        private bool IsGrounded()
        {
            playerColliderBounds = playerCollider.bounds.center;
            playerColliderSize = playerCollider.bounds.size;
            RaycastHit2D raycastHit = Physics2D.BoxCast( playerColliderBounds, playerColliderSize, 0f, Vector2.down, heightToGround, ground);
            return raycastHit.collider != null;
        }
    }
}
