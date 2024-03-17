using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXPManager : MonoBehaviour
{
    public static PlayerXPManager Instance;
    public float PlayerXP {get; private set;}
    public int PlayerLevel {get; private set;}
    public float XPToNextLevel {get; private set;}

    [System.Serializable]
    public struct SaveData
    {
        public int         savePlayerLevel;
        public float       savePlayerXP;
        public float       saveXPToNextLevel;
    }

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

    public void AddXP(float xp)
    {
        if(xp > XPToNextLevel)
        {
            float tempDifference = xp - XPToNextLevel;
            AddLevel(1);
            XPToNextLevel = PlayerLevel * 2f;
            SetXP(tempDifference,XPToNextLevel);
        }
        else
        {
            PlayerXP = PlayerXP + xp;
        }

        ViewPlayerXP.Instance.UpdatePlayerXP(PlayerXP,XPToNextLevel);
    }   

    public void AddLevel(int level)
    {
        PlayerLevel = PlayerLevel + level;
        PlayerRewards.Instance.UnlockReward(PlayerLevel);
        ViewPlayerXP.Instance.UpdatePlayerLevel(PlayerLevel);
    }

    public void RemoveXP(float xp)
    {
        if(PlayerXP < xp)
        {
            float tempDifference = PlayerXP - xp;
            RemoveLevel(1);
            XPToNextLevel = PlayerLevel * 2f;
            SetXP(tempDifference,XPToNextLevel);
        }
        else
        {
            PlayerXP = PlayerXP - xp;
            XPToNextLevel = XPToNextLevel + xp;   
        }

        ViewPlayerXP.Instance.UpdatePlayerXP(PlayerXP,XPToNextLevel);
    }

    public void RemoveLevel(int level)
    {
        if(PlayerLevel > 1)
        {
            PlayerLevel = PlayerLevel - level;
            ViewPlayerXP.Instance.UpdatePlayerLevel(PlayerLevel);
        }
    } 

    public void SetXP(float newXP, float xpToNextLevel)
    {
        PlayerXP = newXP;
        XPToNextLevel = xpToNextLevel;
        ViewPlayerXP.Instance.UpdatePlayerXP(PlayerXP,XPToNextLevel);
    }

    public void SetLevel(int newLevel)
    {
        PlayerLevel = newLevel;
        ViewPlayerXP.Instance.UpdatePlayerLevel(PlayerLevel);
    }

    public void ResetInfomartion()
    {
        PlayerLevel = 1;
        PlayerXP = 0f;
        XPToNextLevel = PlayerLevel * 2f;
    }

    public SaveData GetSaveData()
    {
        SaveData saveData;
        saveData.savePlayerLevel = PlayerLevel;
        saveData.savePlayerXP = PlayerXP;
        saveData.saveXPToNextLevel = XPToNextLevel;
        return saveData;
    }

    public void LoadSaveData(SaveData saveData)
    {
        PlayerLevel = saveData.savePlayerLevel;
        PlayerXP = saveData.savePlayerXP;
        XPToNextLevel = saveData.saveXPToNextLevel;
        SetLevel(PlayerLevel);
        SetXP(PlayerXP,XPToNextLevel);
    }
}
