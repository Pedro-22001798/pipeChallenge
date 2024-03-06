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
    [SerializeField] private GameObject emptyGrid, levelCreationInformationCanvas, actionCanvas, pipeActionCanvas;
    [SerializeField] private TextMeshProUGUI rowsText, colsText;
    [SerializeField] private Sprite normalSprite, curveSprite, lightSprite, endSprite, mixSprite;
    [SerializeField] private Transform pipeContainer;
    private List<LevelCreator_Pipe> allPipeClicks;
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

    public void UpdatePipe(int row, int col, PipeType typeOfPipe, float rotation, SpriteRenderer pipeImage, Transform pipeParent)
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
        pipeParent.position = new UnityEngine.Vector3(col,-row,0f);
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
        allPipeClicks = new List<LevelCreator_Pipe>();
        for(int col = 1; col <= cols; col++)
        {
            for(int row = 1; row <= rows; row++)
            {
                GameObject emptyPipe = Instantiate(emptyGrid,new UnityEngine.Vector3(col,-row,0),UnityEngine.Quaternion.identity,pipeContainer);
                LevelCreator_Pipe pipeInfo = emptyPipe.GetComponent<LevelCreator_Pipe>();
                LevelCreator_PipeClick pipeClick = emptyPipe.GetComponent<LevelCreator_PipeClick>();
                allPipeClicks.Add(pipeInfo);
                pipeInfo.DefineInformation(row,col);
            }
        }
    }

    public void ViewActionCanvas(int row, int col,LevelCreator_Pipe pipe)
    {
        allActionCanvas = GameObject.FindGameObjectsWithTag("ActionCanvas");
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
            GameObject actionCanvas = Instantiate(pipeActionCanvas,new UnityEngine.Vector3(col,-row + 1.4f,0f),UnityEngine.Quaternion.identity);
            LevelCreator_ActionCanvas levelCreatorActionCanvas = actionCanvas.GetComponent<LevelCreator_ActionCanvas>();
            levelCreatorActionCanvas.GetInitialInformation(pipe);
        }
    }

    public void RemovePipe(int row, int col)
    {
        foreach(Transform pipe in pipeContainer)
        {
            LevelCreator_Pipe pipeInformation = pipe.GetComponent<LevelCreator_Pipe>();
            if(pipeInformation.Row == row && pipeInformation.Col == col)
            {
                allPipeClicks.Remove(pipeInformation);
                Destroy(pipe.gameObject);
            }
        }

        allActionCanvas = GameObject.FindGameObjectsWithTag("ActionCanvas");
        foreach(GameObject canvas in allActionCanvas)
        {
            Destroy(canvas);
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

    public void FinishLevelCreation()
    {
        string level = string.Empty;
    
        // ("light,0,mix,0,curve,90\n" +
        //  "empty,0,normal,0,normal,0\n" +
        //  "empty,0,end,180,end,180"

        int levelRows = rows;
        int levelCols = cols;

        for(int row = 1; row <= levelRows; row++)
        {
            for(int col = 1; col <= levelCols; col++)
            {
                if(col == 1)
                {
                    level += "\"";
                }
                LevelCreator_Pipe pipe = FindPipe(row,col);
                if(pipe != null)
                {
                    PipeType typeOfPipe = pipe.TypeOfPipe;
                    float rotation = pipe.Rotation;
                    level += $"{typeOfPipe.ToString()},{rotation.ToString()}";
                }
                if(col == levelCols)
                {
                    if(row < levelRows)
                        level += "\\n\" +\n";
                    else
                        level += "\"";
                }
                else
                {
                    level += ",";
                }
            }
        }

        Debug.Log(level);
    }

    public LevelCreator_Pipe FindPipe(int row, int col)
    {
        LevelCreator_Pipe pipe = null;

        foreach(LevelCreator_Pipe tempPipe in allPipeClicks)
        {
            if(tempPipe.Row == row && tempPipe.Col == col)
            {
                pipe = tempPipe;
            }
        }

        return pipe;
    }
}
