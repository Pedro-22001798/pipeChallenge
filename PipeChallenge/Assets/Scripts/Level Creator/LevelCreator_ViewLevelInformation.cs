using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelCreator_ViewLevelInformation : MonoBehaviour
{
    public static LevelCreator_ViewLevelInformation Instance {get; private set;}
    private int rows, cols;
    [SerializeField] private GameObject emptyGrid;
    [SerializeField] private TextMeshProUGUI rowsText, colsText;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateView(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        rowsText.text = rows.ToString();
        colsText.text = cols.ToString();
    }

    public void PopulateGrid(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;        
    }
}
