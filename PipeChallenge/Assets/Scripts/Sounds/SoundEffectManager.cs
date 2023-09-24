using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance {get; private set;}
    [SerializeField] private AudioSource[] audioSource;
    [SerializeField] private AudioMixer audioMixer;
    private bool isMuted = false;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        switch(soundEffect)
        {
            case SoundEffect.wrong:
                audioSource[0].Stop();
                audioSource[0].Play();
                break;
            case SoundEffect.rotate:
                audioSource[1].Stop();
                audioSource[1].Play();
                break;
            case SoundEffect.transition:
                audioSource[2].Stop();
                audioSource[2].Play();
                break;
            case SoundEffect.win:
                audioSource[3].Stop();
                audioSource[3].Play();
                break;
            case SoundEffect.interfaceclick:
                audioSource[4].Stop();
                audioSource[4].Play();
                break;
        }   
    }

    public void ChangeVolume()
    {
        isMuted = !isMuted;
        if(!isMuted)
        {
            audioMixer.SetFloat("SoundEffectVolume", 0f);
        }
        else
        {
            audioMixer.SetFloat("SoundEffectVolume", -80f);
        }
    }
}
