using UnityEngine;

using PlayerPhysics;
public class CoinController : MonoBehaviour
{
    private SoundManager localSoundManager; 
    private void Awake() {
        localSoundManager = SoundManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.PickUpCoin();
            localSoundManager.Play(SoundType.Scored);
            Destroy(gameObject);
        }
    }
}
