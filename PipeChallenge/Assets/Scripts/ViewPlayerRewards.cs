using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayerRewards : MonoBehaviour
{
    public static ViewPlayerRewards Instance { get; private set; }
    public bool RewardToClaim {get; private set;}
    [SerializeField] private Animator rewardClaimFeedback;
    [SerializeField] private GameObject l1,l2,l3,l4,l5,l6,l7,l8,l9,l10;
    
    void Awake()
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

    public void ActivateRewardFeedback()
    {
        if(!RewardToClaim)
        {
            rewardClaimFeedback.SetTrigger("TurnOnFeedback");
        }
    }

    public void OpenRewardClaim(int level)
    {
        rewardClaimFeedback.SetTrigger("TurnOffFeedback");
        int playerLevel = level;

        switch(playerLevel)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }
}
