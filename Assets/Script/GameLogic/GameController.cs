
using UnityEngine;
using UnityEngine.SceneManagement;
using LifeMapper;

public class GameController : MonoBehaviour
{
    
    #region MainMenu
        public GameObject lobbyPanel;
        public void startScene(int level){
            SceneManager.LoadSceneAsync(level);
        }
        public void startGame(){
            lobbyPanel.SetActive(true);
        }
    #endregion


    #region GameScene
        public GameObject deadPanel;
        #region LifeManager
            private int lifeLeft = 3;
            public LivesMap instanceLifeMap;

            public int GetLife(){ return lifeLeft; }
            public void AddALife(){ 
                if(lifeLeft < 5){
                    lifeLeft++;
                    instanceLifeMap.AddLifeMark();
                }
            }
            public void ReduceALife(){
                if(lifeLeft > 1){
                    lifeLeft--;
                    instanceLifeMap.DestroyLifeMark();
                    
                }else{
                    lifeLeft--;
                    instanceLifeMap.DestroyLifeMark();
                    ShowDeadPanel();
                }

            }

        #endregion

        #region SavepointManager
            public Transform player;
            public Vector3 playerRespawnPosition;
            public Quaternion playerRespawnRotation;
            public void SavePoint(){
                playerRespawnPosition = player.position;
                playerRespawnRotation = player.rotation;
            }

            public void DeadPanelSetting(){
                if(lifeLeft > 1){
                    ReduceALife();
                    BackToSave();
                    Debug.Log("Jumping back to savepoint.");
                }else{
                    AppReload();
                    Debug.Log("Reloading the application.");
                }
            }

        #endregion

        #region SceneManager

            public void ShowDeadPanel(){
                deadPanel.SetActive(true);
            }

            public void BackToSave(){
                player.GetComponent<Animator>().Play("Idle");
                player.transform.SetPositionAndRotation(playerRespawnPosition, playerRespawnRotation);
                deadPanel.SetActive(false);
            }
            public void AppReload(){
                SceneManager.LoadScene(1);
            }

            public void AppQuit(){
                Application.Quit();
            }

        #endregion
    #endregion

    
}
