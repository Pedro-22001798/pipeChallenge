using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCreator_PipeClick : MonoBehaviour
{
    //[SerializeField] private GameObject actionCanvas;
    [SerializeField] private TextMeshProUGUI rowText, colText;
    private int row, col;
    private LevelCreator_Pipe pipe;

    public void DefineInformation(int row, int col)
    {
        this.row = row;
        this.col = col;
        pipe = GetComponent<LevelCreator_Pipe>();
        // rowText.text = row.ToString();
        // colText.text = col.ToString();

    }

    void OnMouseDown() 
    {
        LevelCreator_ViewLevelInformation.Instance.ViewActionCanvas(row, col,pipe);
    }  

    // public void TurnOnCanvas()
    // {
    //     actionCanvas.SetActive(true);
    // }  

    // public void TurnOffCanvas()
    // {
    //     actionCanvas.SetActive(false);
    // }
}
