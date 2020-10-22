
using UnityEngine;
using UnityEngine.SceneManagement;

using PlayerPhysics;
public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            //Next level
            Debug.Log("VICTORY.. Off to next map.");
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.SaveScore();
            
            //SceneManager.LoadScene(0);
        }
    }
}
