using UnityEngine;

namespace MainCharecterInterface
{
    [RequireComponent(typeof(Animator))]
    public class MainCharecterController : MonoBehaviour
    {
        Animator MainCharecter;

        void Start()
        {
            MainCharecter = this.GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                MainCharecter.SetFloat("speed", 0.6f);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                MainCharecter.SetBool("couchB", true);
                MainCharecter.SetTrigger("couchT");
            }
            
            if (Input.GetKeyUp(KeyCode.D))
            {
                MainCharecter.SetFloat("speed", 0.3f);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                MainCharecter.SetBool("couchB", false);
            }
        }
    }
}
