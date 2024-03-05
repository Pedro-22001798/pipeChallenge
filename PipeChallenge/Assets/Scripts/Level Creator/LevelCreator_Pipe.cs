using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator_Pipe : MonoBehaviour
{
    public int Row {get; private set;}
    public int Col {get; private set;}
    public PipeType TypeOfPipe {get; private set;}
    public float Rotation {get; private set;}
    public Image PipeImage {get; private set;}

    public void DefineInformation(int row, int col)
    {
        this.Row = row;
        this.Col = col;
        PipeImage = GetComponent<Image>();
        LevelCreator_PipeClick pipeClick = GetComponent<LevelCreator_PipeClick>();
        pipeClick.DefineInformation(Row,Col);
    }

    public void ChangePipeType(string newType)
    {
        switch(newType)
        {
            case "normal":
                TypeOfPipe = PipeType.normal;
                break;
            case "curve":
                TypeOfPipe = PipeType.curve;
                break;
            case "end":
                TypeOfPipe = PipeType.end;
                break;
            case "light":
                TypeOfPipe = PipeType.light;
                break;
            case "mix":
                TypeOfPipe = PipeType.mix;
                break;
            case "empty":
                TypeOfPipe = PipeType.empty;
                break;
        }

        LevelCreator_ViewLevelInformation.Instance.UpdatePipe(Row,Col,TypeOfPipe,Rotation,PipeImage,this.transform);
    }

    public void RotatePipe(float rotation)
    {
        Rotation += 90f;
        if(Rotation == 360f)
        {
            Rotation = 0;
        }
        else if(Rotation == -360f)
        {
            Rotation = 0;
        }

        LevelCreator_ViewLevelInformation.Instance.UpdatePipe(Row,Col,TypeOfPipe,Rotation,PipeImage,this.transform);
    }
}
