using UnityEngine;

namespace PlayerPhysics
{
    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        Animator mainCharecter_A;
        BoxCollider2D mainCharecter_C;

        // Variables for Input. vertical and horizontal.
        float player_Speed;
        float player_Vertical;

        // Actual transform scale of player.
        Vector3 player_Scale;

        // Variables for player's stand, jump and couch states.
        Vector2 playerColliderScale_Stand;
        Vector2 playerColliderOffset_Stand;

        Vector2 playerColliderScale_Couch;
        Vector2 playerColliderOffset_Couch;
             
        //Vector2 playerColliderScale_Jump;
        //Vector2 playerColliderOffset_Jump;

        void Start()
        {
            mainCharecter_A = GetComponent<Animator>();
            mainCharecter_C = GetComponent<BoxCollider2D>();

            player_Scale = transform.localScale;

            playerColliderScale_Stand = mainCharecter_C.size;
            playerColliderOffset_Stand = mainCharecter_C.offset;

            playerColliderScale_Couch = new Vector2(0.9175335f, 1.296851f);
            playerColliderOffset_Couch = new Vector2(-0.1247323f, 0.6194392f);

            //playerColliderScale_Jump = new Vector2(0.8660495f, 1.317989f);
            //playerColliderOffset_Jump = new Vector2(0.05765058f, 1.778642f);
        }

        void Update()
        {
            // Recieving Inputs every frame.
            player_Speed = Input.GetAxisRaw("Horizontal");
            player_Vertical = Input.GetAxisRaw("Vertical");

            // Player Run motion section.
            mainCharecter_A.SetFloat("speed", Mathf.Abs(player_Speed));
            if(player_Speed<0)
            {
                player_Scale.x = -1f * Mathf.Abs(player_Scale.x);
            }
            else if(player_Speed > 0)
            {
                player_Scale.x = Mathf.Abs(player_Scale.x);
            }

            // Player Jump motion section.
            if (player_Vertical > 0)
            {
                mainCharecter_A.Play("Jump");

                //ResizePlayerCollider(playerColliderScale_Jump, playerColliderOffset_Jump);
            }
            // We might need to use animations and add colliders in the jumping animation itself for perfection.
            //else if (player_Vertical <= 0)
            //{
            //    ResizePlayerCollider(playerColliderScale_Stand, playerColliderOffset_Stand);
            //}

            // Player couch state section
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                mainCharecter_A.Play("Couch");
                mainCharecter_A.SetBool("couchB", true);
                ResizePlayerCollider(playerColliderScale_Couch, playerColliderOffset_Couch);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                mainCharecter_A.SetBool("couchB", false);
                ResizePlayerCollider(playerColliderScale_Stand, playerColliderOffset_Stand);
            }

            transform.localScale = player_Scale;
        }

        void ResizePlayerCollider(Vector2 scale_Temp, Vector2 offset_Temp)
        {
            mainCharecter_C.size = scale_Temp;
            mainCharecter_C.offset = offset_Temp;
        }
    }
}
