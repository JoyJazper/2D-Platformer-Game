
using UnityEngine;
using UnityEngine.SceneManagement;

using PlayerPhysics;

public class BoundsLifeCheck : MonoBehaviour
{
    public Transform player;
    private Vector3 playerRespawnPosition;
    private Quaternion playerRespawnRotation;
    private int lifesLeft = 3;

    private void Awake() {
        playerRespawnPosition = player.position;
        playerRespawnRotation = player.rotation;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //if(other.gameObject.CompareTag("Player"))
        if(other.gameObject.GetComponent<PlayerController>() != null){
            --lifesLeft;
            if(lifesLeft == 0){
                //Dead Panel show
                Debug.Log("Player is dead.");
                SceneManager.LoadScene(0);
            }else{
                Debug.Log("Player respawning.");
                other.gameObject.transform.SetPositionAndRotation(playerRespawnPosition, playerRespawnRotation);
            }

        }

    }
}
