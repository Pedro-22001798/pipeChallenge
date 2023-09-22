using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
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
        playerScore.AddScore(1);
        currentLevel.PassLevel();
        levelLoader.UnlockNextLevel();
    }

    public bool IsLevelPassed()
    {
        return currentLevel.IsPassed;
    }
}
