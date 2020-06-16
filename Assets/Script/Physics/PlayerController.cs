using UnityEngine;

namespace PlayerPhysics
{
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        Animator MainCharecter;

        float player_Speed;

        Vector3 player_Scale;

        void Start()
        {
            MainCharecter = GetComponent<Animator>();
            player_Scale = transform.localScale;
        }

        void Update()
        {
            player_Speed = Input.GetAxisRaw("Horizontal");
            MainCharecter.SetFloat("speed", Mathf.Abs(player_Speed));

            if(player_Speed<0)
            {
                player_Scale.x = -1f * Mathf.Abs(player_Scale.x);
            }
            else if(player_Speed > 0)
            {
                player_Scale.x = Mathf.Abs(player_Scale.x);
            }

            transform.localScale = player_Scale;
        }
    }
}
