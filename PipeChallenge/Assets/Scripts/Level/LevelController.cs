using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private ConnectionsController connectionsController;
    private List<IPipe> allEndingPipes = new List<IPipe>();
    private ILevel currentLevel;

    public void LoadNewLevel(ILevel level)
    {
        currentLevel = level;
        allEndingPipes = new List<IPipe>();
        allEndingPipes = level.GetAllEndingPipes();
        connectionsController.DefineLevel(currentLevel);
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
}
