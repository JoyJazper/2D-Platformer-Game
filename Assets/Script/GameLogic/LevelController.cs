
using UnityEngine;
using UnityEngine.SceneManagement;

using PlayerPhysics;
public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            //Next level
            Debug.Log("VICTORY.. Off to next map.");
            //SceneManager.LoadScene(0);
        }
    }
}
