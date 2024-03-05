using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator_GetInitialInformation : MonoBehaviour
{
    public int Rows {get; private set;}
    public int Cols {get; private set;}

    void Start()
    {
        ResetLevel();
    }

    public void CreateLevel()
    {
        if(Rows > 0 && Cols > 0)
            LevelCreator_ViewLevelInformation.Instance.PopulateGrid(Rows,Cols);
    }

    public void ResetLevel()
    {
        Cols = 0;
        Rows = 0;
        UpdateView();
    }

    public void MoreRow()
    {
        Rows++;
        UpdateView();
    }

    public void MoreCol()
    {
        Cols++;
        UpdateView();
    }

    public void LessRow()
    {
        if(Rows > 0)
        {
            Rows--;
            UpdateView();
        }
    }

    public void LessCol()
    {
        if(Cols > 0)
        {
            Cols--;
            UpdateView();
        }
    }

    public void UpdateView()
    {
        LevelCreator_ViewLevelInformation.Instance.UpdateView(Cols,Rows);
    }
}
