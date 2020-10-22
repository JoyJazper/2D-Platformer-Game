using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
    public GameObject levelScene;
    private Button startButton;
    private SoundManager localSoundManager; 
    private void Awake() {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(StartButtonPressed);
        localSoundManager = SoundManager.Instance; 
    }


    public void StartButtonPressed() {
        localSoundManager.Play(SoundType.ButtonPressed);
        levelScene.SetActive(true);
    }
}
