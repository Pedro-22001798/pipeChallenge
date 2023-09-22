using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    private ILevel currentLevel;
    [SerializeField] private Transform allPipesTransfrom;
    private List<PipeClick> allPipes;

    public void DefineLevel(ILevel newLevel)
    {
        currentLevel = levelController.GetCurrentLevel();
        // allPipes = currentLevel.GetAllPipes();
    }

    public void CheckConnections()
    {
        allPipes = new List<PipeClick>();
        foreach(Transform t in allPipesTransfrom)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            allPipes.Add(pc);
        }
        
        foreach(PipeClick pc in allPipes)
        {
            if(pc.Pipe.TypeOfPipe != PipeType.light && pc.Pipe.TypeOfPipe != PipeType.end)
            {
                List<PipeClick> allConnections = new List<PipeClick>();
                allConnections = pc.GetPipeConnections();
                if(allConnections.Count > 0)
                {
                    foreach(PipeClick pc2 in allConnections)
                    {
                        if(pc2.IsLight())
                        {
                            pc.LightPipe();
                        }
                        else
                        {
                            if(pc.IsLight())
                            {
                                pc2.LightPipe();
                            }
                            else
                            {
                                pc2.UnlightPipe();
                            }
                        }
                    }
                }
                else
                {
                    pc.UnlightPipe();
                }
            }
        }
    }
}
