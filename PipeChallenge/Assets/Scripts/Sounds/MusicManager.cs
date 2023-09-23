using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusics;
    public Music CurrentMusic {get; private set;} = Music.abstractworld;

    void Start()
    {
        PlayMusic(CurrentMusic);
    }

    public void ChangeMusic(Music newMusic)
    {
        audioSource.Stop();
        CurrentMusic = newMusic;
        PlayMusic(CurrentMusic);
    }

    private void PlayMusic(Music newMusic)
    {
        switch(newMusic)
        {
            case Music.happychill:
                audioSource.clip = backgroundMusics[0];
                break;
            case Music.lostdream:
                audioSource.clip = backgroundMusics[1];
                break;
            case Music.calmpiano:
                audioSource.clip = backgroundMusics[2];
                break;
            case Music.abstractworld:
                audioSource.clip = backgroundMusics[3];
                break;
            default:
                audioSource.clip = backgroundMusics[3];
                break;
        }

        audioSource.Play();
    }
}
