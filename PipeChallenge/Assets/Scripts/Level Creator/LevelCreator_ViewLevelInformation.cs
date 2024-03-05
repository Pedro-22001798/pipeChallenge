using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelCreator_ViewLevelInformation : MonoBehaviour
{
    public static LevelCreator_ViewLevelInformation Instance {get; private set;}
    [SerializeField] private CameraController cameraController;
    private int rows, cols;
    [SerializeField] private GameObject emptyGrid;
    [SerializeField] private TextMeshProUGUI rowsText, colsText;
    [SerializeField] private Sprite normalSprite, curveSprite, lightSprite, endSprite, mixSprite;
    [SerializeField] private Transform pipeContainer;

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

    public void UpdatePipe(int row, int col, PipeType typeOfPipe, float rotation, Image pipeImage, Transform pipeParent)
    {
        switch(typeOfPipe)
        {
            case PipeType.normal:
                pipeImage.sprite = normalSprite;
                break;
            case PipeType.curve:
                pipeImage.sprite = curveSprite;
                break;
            case PipeType.light:
                pipeImage.sprite = lightSprite;
                break;
            case PipeType.end:
                pipeImage.sprite = endSprite;
                break;
            case PipeType.mix:
                pipeImage.sprite = mixSprite;
                break;
            case PipeType.empty:
                pipeImage.sprite = null;
                break;
        }
        pipeParent.position = new UnityEngine.Vector3(0f,0f,0f);
        pipeParent.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0f,0f,rotation));
    }

    public void PopulateGrid(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;  
        cameraController.CalculateCameraPosition(cols,rows);
        cameraController.CalculateCameraSize(cols,rows); 
        for(int col = 1; col <= cols; col++)
        {
            for(int row = 1; row <= rows; row++)
            {
                GameObject emptyPipe = Instantiate(emptyGrid,new UnityEngine.Vector3(col,-row,0),UnityEngine.Quaternion.identity,pipeContainer);
                LevelCreator_Pipe pipeInfo = emptyPipe.GetComponent<LevelCreator_Pipe>();
                pipeInfo.DefineInformation(row,col);
            }
        }
    }
}
