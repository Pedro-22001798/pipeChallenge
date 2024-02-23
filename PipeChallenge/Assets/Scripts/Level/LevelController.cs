using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AllLevels allLevels;
    [SerializeField] private LevelScoreCalculator scoreCalculator;
    [SerializeField] private SaveManager saveManager;
    private List<IPipe> allEndingPipes = new List<IPipe>();
    private ILevel currentLevel;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private View view;
    private bool hasMoreMoves;

    public void LoadNewLevel(ILevel level)
    {
        currentLevel = level;
        allEndingPipes = new List<IPipe>();
        allEndingPipes = level.GetAllEndingPipes();
        hasMoreMoves = true;
        LevelTimer.Instance.StartTimer();
    }

    public void CheckIfLevelWon()
    {
        foreach(IPipe p in allEndingPipes)
        {
            if(p.IsLight == false)
            {
                if(!hasMoreMoves)
                {
                    Debug.Log("perdeste!");
                }
                return;
            }
        }

        PassLevel();
    }

    public ILevel GetCurrentLevel()
    {
        return currentLevel;
    }

    public void PassLevel()
    {
        float elpsedTime = LevelTimer.Instance.StopTimer();
        int tempPlayerScore = scoreCalculator.CalculateScore(currentLevel,elpsedTime);
        view.WinLevel(tempPlayerScore);
        if(!currentLevel.IsPassed)
        {
            levelLoader.UnlockNextLevel();
        }
        if(tempPlayerScore > currentLevel.Score)
        {
            playerScore.AddScore((tempPlayerScore-currentLevel.Score));
            currentLevel.PassLevel(tempPlayerScore);
        }
        saveManager.SaveGame();
        GameStateMachine.Instance.PauseGame();
        StartCoroutine(GoNextLevel());
    }

    public bool IsLevelPassed()
    {
        return currentLevel.IsPassed;
    }

    public void ChangeMoveStatus(bool newStatus)
    {
        this.hasMoreMoves = newStatus;
    }

    private IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        allLevels.NextLevel(true);
    }
}
