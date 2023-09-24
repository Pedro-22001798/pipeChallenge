using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private Transform allPipesTransfrom;
    private List<PipeClick> allPipes;

    public void DefinePipes()
    {
        allPipes = new List<PipeClick>();
        foreach(Transform t in allPipesTransfrom)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            if(pc != null)
                allPipes.Add(pc);
        }
    }

    public void CheckConnections()
    {
            foreach(PipeClick pc in allPipes)
            {
                if(pc.Pipe.TypeOfPipe != PipeType.light)
                    pc.UnlightPipe();
            }

            foreach(PipeClick pc in allPipes)
            {
                List<PipeClick> allConnections = new List<PipeClick>();
                allConnections = pc.GetPipeConnections();
                if(allConnections.Count > 0)
                {
                    foreach(PipeClick pc2 in allConnections)
                    {
                        if(pc2.Pipe.TypeOfPipe == PipeType.light)
                        {
                            pc.LightPipe();
                        }
                        else
                        {
                            if(pc2.IsLight())
                            {
                                pc.LightPipe();
                            }
                        }
                    }
                }
                else
                {
                    if(pc.Pipe.TypeOfPipe != PipeType.light)
                        pc.UnlightPipe();
                }
            }

            if(levelController.CheckIfLevelWon())
            {
                levelController.PassLevel();
            }
        }
}
