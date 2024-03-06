using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelCreator_ViewLevelInformation : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    private int rows, cols;
    [SerializeField] private GameObject emptyGrid, levelCreationInformationCanvas, actionCanvas;
    [SerializeField] private TextMeshProUGUI rowsText, colsText;
    [SerializeField] private Sprite normalSprite, curveSprite, lightSprite, endSprite, mixSprite;
    [SerializeField] private Transform pipeContainer;
    private List<LevelCreator_PipeClick> allPipeClicks;
    private GameObject[] allActionCanvas;

    public static LevelCreator_ViewLevelInformation Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null && Instance != this)
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
        levelCreationInformationCanvas.SetActive(false);
        actionCanvas.SetActive(true);
        this.rows = rows;
        this.cols = cols;  
        cameraController.CalculateCameraPosition(cols,rows);
        cameraController.CalculateCameraSize(cols,rows); 
        allPipeClicks = new List<LevelCreator_PipeClick>();
        for(int col = 1; col <= cols; col++)
        {
            for(int row = 1; row <= rows; row++)
            {
                GameObject emptyPipe = Instantiate(emptyGrid,new UnityEngine.Vector3(col,-row,0),UnityEngine.Quaternion.identity,pipeContainer);
                LevelCreator_Pipe pipeInfo = emptyPipe.GetComponent<LevelCreator_Pipe>();
                LevelCreator_PipeClick pipeClick = emptyPipe.GetComponent<LevelCreator_PipeClick>();
                allPipeClicks.Add(pipeClick);
                pipeInfo.DefineInformation(row,col);
            }
        }
        allActionCanvas = GameObject.FindGameObjectsWithTag("ActionCanvas");
    }

    public void ViewActionCanvas(GameObject actionCanvas)
    {
        bool isAnyCanvasOn = false;
        foreach(GameObject canvas in allActionCanvas)
        {
            if(canvas.activeSelf)
            {
                isAnyCanvasOn = true;
            }
        }

        if(!isAnyCanvasOn)
        {
            foreach(GameObject canvas in allActionCanvas)
            {
                canvas.SetActive(false);
            }
            actionCanvas.SetActive(true);
        }
    }

    public void RestartLevelCreation()
    {
        foreach(Transform pipe in pipeContainer)
        {
            Destroy(pipe.gameObject);
        }
        actionCanvas.SetActive(false);
        levelCreationInformationCanvas.SetActive(true);
        LevelCreator_GetInitialInformation.Instance.ResetLevel();
    }
}
