using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPrefab : MonoBehaviour
{
    [SerializeField] private Music music;
    private bool isUnlocked = false;

    public void UnlockMusic()
    {
        if(!isUnlocked)
        {
            isUnlocked = true;
        }
        ChooseMusic();
    }

    public void ChooseMusic()
    {
        MusicManager.Instance.ChangeMusic(music,this.transform);
        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.interfaceclick);
    }

    public Music GetMusic()
    {
        return music;
    }
}
