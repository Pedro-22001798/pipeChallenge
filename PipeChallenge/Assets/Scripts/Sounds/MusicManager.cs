using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {get; private set;}
    [SerializeField] private Transform musicContainer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusics;
    public Music CurrentMusic {get; private set;} = Music.abstractworld;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private View view;
    private bool isMuted = false;
    private bool isActive = false;

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

        foreach(Transform t in musicContainer)
        {
            MusicPrefab mp = t.GetComponent<MusicPrefab>();
            if(mp.GetMusic() == CurrentMusic)
            {
                ChangeMusic(mp.GetMusic(),t);
            }
        }
    }

    public void ChangeMusic(Music newMusic)
    {
        audioSource.Stop();
        CurrentMusic = newMusic;
        PlayMusic(CurrentMusic);
    }

    public void ChangeMusic(Music newMusic, Transform musicTransform)
    {
        audioSource.Stop();
        CurrentMusic = newMusic;
        view.ActiveSkinButton(musicTransform,musicContainer);
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

    public void ChangeVolume()
    {
        isMuted = !isMuted;
        if(!isMuted)
        {
            audioMixer.SetFloat("MusicVolume", 0f);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", -80f);
        }
    }

    public void ActivateDeactivateMusicContainer()
    {
        isActive = !isActive;
        if(!isActive)
        {
            foreach(Transform t in musicContainer)
            {
                Animator anim = t.GetComponent<Animator>();
                anim.SetTrigger("Hide");
            }
            StartCoroutine(WaitToDeactivate());
        }
        else
        {
            musicContainer.gameObject.SetActive(isActive);
        }
    }

    private IEnumerator WaitToDeactivate()
    {
        yield return new WaitForSeconds(0.3f);
        musicContainer.gameObject.SetActive(false);
    }
}
