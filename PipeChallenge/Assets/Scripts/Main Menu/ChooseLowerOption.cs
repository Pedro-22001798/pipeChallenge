using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLowerOption : MonoBehaviour
{
    [SerializeField] private Animator playAnimator, shopAnimator, skinsAnimator, settingsAnimator;
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
