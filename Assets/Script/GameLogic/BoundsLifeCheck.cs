
using UnityEngine;
using UnityEngine.SceneManagement;

using PlayerPhysics;

public class BoundsLifeCheck : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerEnter2D(Collider2D other) {
        //if(other.gameObject.CompareTag("Player"))
        if(other.gameObject.GetComponent<PlayerController>() != null){
            gameController.ShowDeadPanel();
        }
    }
}
