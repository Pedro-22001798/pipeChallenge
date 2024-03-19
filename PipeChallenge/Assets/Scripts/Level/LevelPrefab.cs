using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPrefab : MonoBehaviour
{
    private LevelLoader levelLoader;
    private CameraShake cameraShake;
    private View view;
    public ILevel level {get; private set;}
    public int Stars {get; private set;}
    [SerializeField] private TextMeshProUGUI levelNumber;
    [SerializeField] private Transform[] stars;
    [SerializeField] private GameObject lockObject;

    public void DefineLevel(ILevel level, View view)
    {
        GameObject levelLoaderParent = GameObject.FindWithTag("LevelParent");
        levelLoader = levelLoaderParent.GetComponent<LevelLoader>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        this.level = level;
        this.Stars = level.Score;
        this.view = view;
        UpdateLock();
        UpdateStars();
    }

    private void UpdateLock()
    {
        if(!level.IsLocked)
        {
            levelNumber.text = $"#{level.LevelNumber}";
            lockObject.SetActive(false);
        }
        else
        {
            lockObject.SetActive(true);
            levelNumber.gameObject.SetActive(false);
        }
    }

    private void UpdateStars()
    {
        foreach(Transform t in stars)
        {
            t.gameObject.SetActive(false);
        }

        if(Stars == 0)
        {
            stars[0].gameObject.SetActive(true);
        }
        else if(Stars == 1)
        {
            stars[1].gameObject.SetActive(true);
        }
        else if(Stars == 2)
        {
            stars[2].gameObject.SetActive(true);
        }
        else if(Stars == 3)
        {
            stars[3].gameObject.SetActive(true);
        }
    }

    public void PlayLevel()
    {
        if(!level.IsLocked)
        {
            levelLoader.LoadNewLevel(level);
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.interfaceclick);
            view.HideShowLevelMenu(false);
        }
        else
        {
            SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
            cameraShake.ShakeCamera();
        }
    }
}
