using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevels : MonoBehaviour
{
    private List<ILevel> allLevels = new List<ILevel>();
    private List<int> levelsScore;
    private List<bool> levelsUnlocked = new List<bool>();
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private View view;
    [SerializeField] private CameraShake cameraShake;
    private bool canPassLevel = true;

    [System.Serializable]
    public struct SaveData
    {
        public List<int>          savedLevelsScore;
        public List<bool>         savedLevelsUnlocked;
    }

    public void CreateLevel(ILevel newLevel)
    {
        allLevels.Add(newLevel);
    }

    public bool IsLevelLocked(int levelNumber)
    {
        return allLevels[levelNumber].IsLocked;
    }

    public void NextLevel(bool isAutomaticTransition)
    {
        if(GameStateMachine.Instance.CurrentGameState == GameState.paused)
        {
            if(canPassLevel)
            {
                if(levelLoader.HowManyLevelsExist() > levelLoader.CurrentLevel+1)
                {
                    if(!IsLevelLocked(levelLoader.CurrentLevel+1))
                    {
                        canPassLevel = false;
                        view.LevelTransition();
                        if(isAutomaticTransition)
                        {
                            //view.OpenCloseOptions(false);
                            GameStateMachine.Instance.ResumeGame();
                        }
                        StartCoroutine(LoadAndChangeLevel(levelLoader.CurrentLevel+1));
                    }
                    else
                    {
                        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
                        cameraShake.ShakeCamera();
                    }
                }
                else
                {
                    if(GetLevel(levelLoader.CurrentLevel).IsPassed)
                    {
                        view.HideShowLevelMenu(true);
                    }
                    else
                    {
                        SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
                        cameraShake.ShakeCamera();                        
                    }
                }
            }
        }
    }

    public void PreviousLevel(bool isAutomaticTransition)
    {
        if(GameStateMachine.Instance.CurrentGameState == GameState.paused)
        {
            if(canPassLevel)
            {
                if(levelLoader.CurrentLevel > 0)
                {
                    canPassLevel = false;
                    view.LevelTransition();
                    if(isAutomaticTransition)
                    {
                        //view.OpenCloseOptions(false);
                        GameStateMachine.Instance.ResumeGame();
                    }
                    StartCoroutine(LoadAndChangeLevel(levelLoader.CurrentLevel-1));
                }
                else
                {
                    SoundEffectManager.Instance.PlaySoundEffect(SoundEffect.wrong);
                    cameraShake.ShakeCamera();
                }
            }
        }
    }

    public ILevel GetLevel(int numLevel)
    {
        return allLevels[numLevel];
    }

    public List<ILevel> GetAllLevels()
    {
        return allLevels;
    }

    private IEnumerator LoadAndChangeLevel(int level)
    {
        yield return new WaitForSeconds(0.3f);
        levelLoader.LoadNewLevel(level);
        levelLoader.ChangeLevel(level);  
        canPassLevel = true;    
    }

    public void CreateSaveLists()
    {
        levelsScore = new List<int>();
        levelsUnlocked = new List<bool>();
        foreach(ILevel level in allLevels)
        {
            levelsScore.Add(level.Score);
            levelsUnlocked.Add(level.IsLocked);
        }
    }

    public void SetLevelSavedInformation()
    {
        for(int i = 0; i < allLevels.Count; i++)
        {
            ILevel level = allLevels[i];
            level.LoadSavedLevel(levelsScore[i],levelsUnlocked[i]);
        }
    }

    public SaveData GetSaveData()
    {
        SaveData saveData;
        CreateSaveLists();
        saveData.savedLevelsScore = levelsScore;
        saveData.savedLevelsUnlocked = levelsUnlocked;

        return saveData;
    }

    public void LoadSaveData(SaveData saveData)
    {
        levelsScore = saveData.savedLevelsScore;
        levelsUnlocked = saveData.savedLevelsUnlocked;
    }
}
