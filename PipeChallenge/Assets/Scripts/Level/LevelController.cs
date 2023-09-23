using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AllLevels allLevels;
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
            playerScore.AddScore(1);
            currentLevel.PassLevel();
            levelLoader.UnlockNextLevel();
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
