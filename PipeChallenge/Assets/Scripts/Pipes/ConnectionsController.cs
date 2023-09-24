using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionsController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private Transform allPipesTransfrom;
    private List<PipeClick> allPipes;
    private List<PipeClick> allLights;
    private List<PipeClick> pipesToTurnOn;

    public void DefinePipes()
    {
        allPipes = new List<PipeClick>();
        allLights = new List<PipeClick>();
        foreach(Transform t in allPipesTransfrom)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            if(pc != null)
            {
                allPipes.Add(pc);
                if(pc.Pipe.TypeOfPipe == PipeType.light)
                    allLights.Add(pc);
            }
        }
        StartCoroutine(WaitAndCheckConnections());
    }

    private IEnumerator WaitAndCheckConnections()
    {
        yield return new WaitForSeconds(1f);
        CheckConnections();
    }

    public void CheckConnections()
    {
        foreach(PipeClick pc in allPipes)
        {
            if(pc.Pipe.TypeOfPipe != PipeType.light)
                pc.UnlightPipe();
        }

        pipesToTurnOn = new List<PipeClick>();

        foreach(PipeClick pc in allLights)
        {
            GetConnectedPipes(pc);
        }

        foreach(PipeClick pc in pipesToTurnOn)
        {
            pc.LightPipe();
        }

        if(levelController.CheckIfLevelWon())
        {
            levelController.PassLevel();
        }
    }

    private void GetConnectedPipes(PipeClick pipeClick)
    {
        if (pipeClick.GetConnections().Count == 0 || pipesToTurnOn.Contains(pipeClick))
        {
            return;
        }
        else
        {
            pipesToTurnOn.Add(pipeClick);
            foreach (PipeClick pc in pipeClick.GetConnections())
            {
                GetConnectedPipes(pc);
            }
        }
    }

}

