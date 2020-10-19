using UnityEngine;
using UnityEngine.UI;

namespace PlayerPhysics
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        private Animator playerAnimator;
        private Rigidbody2D playerRigidbody;
        private BoxCollider2D playerCollider;
        public GameController gameController;
        private void Start()
        {
            
            playerAnimator = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<BoxCollider2D>();
            scale = transform.localScale;
            scoreValue.text = score.ToString();
        }


        private void Update()
        {
            IsGrounded();
            GetInput();
            RunCheck();
            JumpCheck();
            CouchCheck();
            MovePlayerHorizontal(horizontal);
        }

        #region HealthScore Mechanism

            public static int lastSavedScore = 0;
            public int score = 0;
            public int health = 1000;
            public Text scoreValue;
            public GameObject gameEndPanel;

            public void SetHealth(int value){
                health = health + value;
                Debug.Log("Health of the player is : "+ health);
                if(health > 0){
                    playerAnimator.Play("Hurt");
                }else{
                    playerAnimator.Play("Death");
                    gameController.ShowDeadPanel();
                    health = 1000;
                }
            }
            public void PickUpCoin(){
                score++;
                scoreValue.text = score.ToString();
            }
            public void SaveScore(){
                //score + saved time + number of lives [Final Score Logic]
                lastSavedScore = score;
            }

        #endregion

        #region PlayerMovement and InputSystem
            private float speed = 35f;
            private float jumpForce = 2300f;
            private float horizontal;
            private float vertical;
            private void MovePlayerVertical()
            {
                playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            }    

            private Vector3 position;
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

            private Vector3 scale;
            private void RunCheck()
            {
                if(!playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
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
                    if (!onAir && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
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
                    if (!onAir)
                    {
                        playerAnimator.Play("Couch");
                        playerAnimator.SetBool("couchB", true);
                    }
                }
                else if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    playerAnimator.SetBool("couchB", false);
                }
            }


            public LayerMask ground;
            private Vector2 playerColliderBounds;
            private Vector2 playerColliderSize;
            private float heightToGround = 0.3f;
            private bool onAir = false;
            private void IsGrounded()
            {
                playerColliderBounds = playerCollider.bounds.center;
                playerColliderSize = playerCollider.bounds.size;
                RaycastHit2D raycastHit = Physics2D.BoxCast( playerColliderBounds, playerColliderSize, 0f, Vector2.down, heightToGround, ground);
                if(raycastHit.collider != null){
                    onAir = false;
                }else{
                    onAir = true;
                }
            }

        #endregion
    }
}