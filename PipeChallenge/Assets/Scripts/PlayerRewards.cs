using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewards : MonoBehaviour
{
    public static PlayerRewards Instance { get; private set; }
    private bool l1,l2,l3,l4,l5,l6,l7,l8,l9,l10;
    
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
    public void UnlockReward(int newPlayerLevel)
    {
        int playerLevel = newPlayerLevel;

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

    public void ClaimReward(int level)
    {
        int playerLevel = level;

        switch(playerLevel)
        {
            case 1:
                l1 = true;
                break;
            case 2:
                l2 = true;
                break;
            case 3:
                l3 = true;
                break;
            case 4:
                l4 = true;
                break;
            case 5:
                l5 = true;
                break;
            case 6:
                l6 = true;
                break;
            case 7:
                l7 = true;
                break;
            case 8:
                l8 = true;
                break;
            case 9:
                l9 = true;
                break;
            case 10:
                l10 = true;
                break;
        }        
    }

    public bool CheckIfRewardClaimed(int level)
    {
        switch(level)
        {
            case 1:
                if(l1 == true) return true;
                break;
            case 2:
                if(l2 == true) return true;
                break;
            case 3:
                if(l3 == true) return true;
                break;
            case 4:
                if(l4 == true) return true;
                break;
            case 5:
                if(l5 == true) return true;
                break;
            case 6:
                if(l6 == true) return true;
                break;
            case 7:
                if(l7 == true) return true;
                break;
            case 8:
                if(l8 == true) return true;
                break;
            case 9:
                if(l9 == true) return true;
                break;
            case 10:
                if(l10 == true) return true;
                break;
        }

        return false;
    }
}
