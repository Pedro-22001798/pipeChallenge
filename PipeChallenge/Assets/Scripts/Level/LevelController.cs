using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<IPipe> allEndingPipes = new List<IPipe>();

    public void LoadNewLevel(List<IPipe> allEndingPipes)
    {
        allEndingPipes = new List<IPipe>();
        this.allEndingPipes = allEndingPipes;
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
}
