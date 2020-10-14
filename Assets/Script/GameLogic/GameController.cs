
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public void appReload(){
        SceneManager.LoadScene(0);
    }

    public void appQuit(){
        Application.Quit();
    }
}
