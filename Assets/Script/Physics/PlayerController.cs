using UnityEngine;

namespace PlayerPhysics
{
    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        private Animator charecterAnimator;

        private float speed;
        private float vertical;
        private Vector3 scale;

        private void Start()
        {
            charecterAnimator = GetComponent<Animator>();
            scale = transform.localScale;
        }

        private void Update()
        {
            GetInput();
            RunCheck();
            JumpCheck();
            CouchCheck();
        }

        private void GetInput()
        {
            speed = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        private void RunCheck()
        {
            charecterAnimator.SetFloat("speed", Mathf.Abs(speed));
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (speed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        private void JumpCheck()
        {
            if (vertical > 0)
            {
                charecterAnimator.Play("Jump");
            }
        }

        private void CouchCheck()
        {
            // Player couch state section
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                charecterAnimator.Play("Couch");
                charecterAnimator.SetBool("couchB", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                charecterAnimator.SetBool("couchB", false);
            }
        }
    }
}
