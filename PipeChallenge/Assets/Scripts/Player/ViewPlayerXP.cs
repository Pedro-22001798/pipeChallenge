using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewPlayerXP : MonoBehaviour
{
    public static ViewPlayerXP Instance;
    [SerializeField] private TextMeshProUGUI playerLevel, playerXP;
    [SerializeField] private Animator playerXPAnimator;
    [SerializeField] private GameObject playerXPParent;

    private IEnumerator XPVisualUpdateCoroutine;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdatePlayerXP(float newXP, float xpToNextLevel)
    {

    }

    public void UpdatePlayerLevel(int newLevel)
    {

    }

    private void NotifyPlayer()
    {

    }

    public void HidePlayerXPInformation()
    {

    }

    public void ShowPlayerXPInformation()
    {

    }
}
