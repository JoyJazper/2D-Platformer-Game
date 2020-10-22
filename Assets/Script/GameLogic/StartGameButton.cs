using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
    public GameObject levelScene;
    private Button startButton;
    private void Awake() {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(StartButtonPressed);
    }
    public void StartButtonPressed() {
        levelScene.SetActive(true);
    }
}
