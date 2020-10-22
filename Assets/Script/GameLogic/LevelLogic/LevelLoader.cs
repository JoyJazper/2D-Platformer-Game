using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button selectedLevel;
    public GameObject LockedTextPanel;
    public GameObject CompletedTextPanel;
    private string levelName;
    private LevelManager levelManager;

    private void Awake() {
        selectedLevel = GetComponent<Button>();
        selectedLevel.onClick.AddListener(() => LoadLevel(name));
        levelManager = LevelManager.Instance;
    }

    private void Start() {
        LevelManager levelManager = LevelManager.Instance;
        if(gameObject.name == "Level1"){
            LevelStatus level1status = levelManager.GetLevelStatus(name);
            Debug.Log("name checked : " + gameObject.name);
            Debug.Log(level1status);
            if(level1status != LevelStatus.Completed){
                levelManager.SetLevelStatus(name, LevelStatus.Unlocked);
            }
        } else {
            Debug.Log("Game Object : " + gameObject.name);
            Debug.Log("Transform : " + GetComponent<Transform>().name);
            Debug.Log("normal name : " + name);
        }
    }

    private void LoadLevel(string level){
        
        if(levelManager == null){
            Debug.LogError("levelManager is not set to an instance");
            return;
        }
        LevelStatus status = levelManager.GetLevelStatus(level);
        if(status == LevelStatus.Locked){
            LockedTextPanel.SetActive(true);
        } else if(status == LevelStatus.Completed){
            CompletedTextPanel.SetActive(true);
        } else {
            SceneManager.LoadScene(level);
        }
    }
}
