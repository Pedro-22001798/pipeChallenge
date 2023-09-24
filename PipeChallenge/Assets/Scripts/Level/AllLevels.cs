using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevels : MonoBehaviour
{
    List<ILevel> allLevels = new List<ILevel>();
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private View view;
    [SerializeField] private CameraShake cameraShake;
    private bool canPassLevel = true;

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
}
