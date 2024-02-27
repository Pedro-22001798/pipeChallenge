using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject warning;
    public void OpenNormalLevelsSelection()
    {

    }

    public void OpenHardcoreLevelsSelection()
    {
        warning.SetActive(true);
    }

    public void OpenDailyChallengeSelection()
    {

    }

    public void AnswerWarning(bool answer)
    {
        if(answer == true)
        {
            warning.SetActive(false);
        }
        else
        {
            warning.SetActive(false);
        }
    }
}
