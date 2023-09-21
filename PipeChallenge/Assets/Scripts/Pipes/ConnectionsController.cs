using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    private ILevel currentLevel;
    List<IPipe> allPipes = new List<IPipe>();

    public void DefineLevel(ILevel newLevel)
    {
        currentLevel = levelController.GetCurrentLevel();
        allPipes = currentLevel.GetAllPipes();
        CheckConnections();
    }

    public void CheckConnections()
    {
        foreach(IPipe p in allPipes)
        {
            if(p.TypeOfPipe != PipeType.light && p.TypeOfPipe != PipeType.end)
            {
                List<IPipe> allConnections = new List<IPipe>();
                allConnections = p.GetConnections();
                foreach(IPipe p2 in allConnections)
                {
                    
                }
            }
        }
    }
}
