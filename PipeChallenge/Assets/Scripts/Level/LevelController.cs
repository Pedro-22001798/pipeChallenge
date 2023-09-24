using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AllLevels allLevels;
    [SerializeField] private LevelScoreCalculator scoreCalculator;
    private List<IPipe> allEndingPipes = new List<IPipe>();
    private ILevel currentLevel;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private View view;

    public void LoadNewLevel(ILevel level)
    {
        currentLevel = level;
        allEndingPipes = new List<IPipe>();
        allEndingPipes = level.GetAllEndingPipes();
    }

    public bool CheckIfLevelWon()
    {
        foreach(IPipe p in allEndingPipes)
        {
            if(p.IsLight == false)
            {
                return false;
            }
        }
        return true;
    }

    public ILevel GetCurrentLevel()
    {
        return currentLevel;
    }

    public void PassLevel()
    {
        view.WinLevel();
        if(!currentLevel.IsPassed)
        {
            levelLoader.UnlockNextLevel();
        }
        int tempPlayerScore = scoreCalculator.CalculateScore(currentLevel,20f);
        if(tempPlayerScore > currentLevel.Score)
        {
            playerScore.AddScore((tempPlayerScore-currentLevel.Score));
            currentLevel.PassLevel(tempPlayerScore);
        }
        GameStateMachine.Instance.PauseGame();
        StartCoroutine(GoNextLevel());
    }

    public bool IsLevelPassed()
    {
        return currentLevel.IsPassed;
    }

    private IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        allLevels.NextLevel(true);
    }
}
