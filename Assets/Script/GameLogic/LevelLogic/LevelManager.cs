
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    

    public LevelStatus GetLevelStatus(string level){
        int status = PlayerPrefs.GetInt(level, 0);
        return (LevelStatus)status;
    }

    public void SetLevelStatus(string level, LevelStatus status){
        PlayerPrefs.SetInt(level, (int)status);
    }
}
