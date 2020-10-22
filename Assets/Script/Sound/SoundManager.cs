using System;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    
    public AudioSource musicBackground;
    public AudioSource soundEffect;
    public AudioSource soundAdditional;
    public SoundDef[] soundsArray;

    public void Play(SoundType type){
        AudioClip clip = GetSoundClip(type);
        if(clip != null){
            soundEffect.PlayOneShot(clip);
        }else{
            Debug.LogError("Sound clip is not found.");
        }
    }

    private AudioClip GetSoundClip(SoundType type){
        SoundDef temp = Array.Find(soundsArray, item => item.type == type);
        if(temp != null)
            return temp.sound;
        return null;
    }
}

[Serializable]
public class SoundDef{
    public AudioClip sound;
    public SoundType type;
}


public enum SoundType{
    ButtonPressed,
    BackGround,
    GameOver,
    Victory,
    Scored,
}