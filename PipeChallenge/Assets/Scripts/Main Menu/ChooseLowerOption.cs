using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLowerOption : MonoBehaviour
{
    [SerializeField] private Animator playAnimator, shopAnimator, skinsAnimator, settingsAnimator;
    [SerializeField] private Material normalSkybox, hardcoreSkybox;

    public void OpenNormalPlay()
    {
        if(GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Normal))
        {
            RenderSettings.skybox = normalSkybox;
            DynamicGI.UpdateEnvironment();
        }
    }

    public void OpenHardcorePlay()
    {
        if(GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Hardcore))
        {
            RenderSettings.skybox = hardcoreSkybox;
            DynamicGI.UpdateEnvironment();
        }
    }

    public void OpenDailyPlay()
    {
        if(GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Daily))
        {
            RenderSettings.skybox = normalSkybox;
            DynamicGI.UpdateEnvironment();            
        }
    }

    public void OpenPlay()
    {
        playAnimator.SetTrigger("Pressed");
        shopAnimator.SetTrigger("Pressed");
        skinsAnimator.SetTrigger("Pressed");
        settingsAnimator.SetTrigger("Pressed");
    }

    public void OpenShop()
    {
        playAnimator.SetTrigger("Pressed");
        shopAnimator.SetTrigger("Pressed");
        skinsAnimator.SetTrigger("Pressed");
        settingsAnimator.SetTrigger("Pressed");
    }

    public void OpenSkins()
    {
        playAnimator.SetTrigger("Pressed");
        shopAnimator.SetTrigger("Pressed");
        skinsAnimator.SetTrigger("Pressed");
        settingsAnimator.SetTrigger("Pressed");
    }

    public void OpenSettings()
    {
        playAnimator.SetTrigger("Pressed");
        shopAnimator.SetTrigger("Pressed");
        skinsAnimator.SetTrigger("Pressed");
        settingsAnimator.SetTrigger("Pressed");
    }
}
