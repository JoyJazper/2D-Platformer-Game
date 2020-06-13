using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player_Object;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<Animator>().SetFloat("speed",0.6f);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            this.GetComponent<Animator>().SetFloat("speed", 0.3f);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("couchB",true);
            this.GetComponent<Animator>().SetTrigger("couchT");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("couchB", false);
        }
    }
}
