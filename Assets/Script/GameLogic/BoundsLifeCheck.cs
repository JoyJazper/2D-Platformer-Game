using UnityEngine;
using PlayerPhysics;

public class BoundsLifeCheck : MonoBehaviour
{
    public GameController gameController;
    private SoundManager localSoundManager;

    private void Awake() {
        localSoundManager = SoundManager.Instance;
    } 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerController>() != null){
            localSoundManager.Play(SoundType.GameOver);
            gameController.ShowDeadPanel();
        }
    }
}
