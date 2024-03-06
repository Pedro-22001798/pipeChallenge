using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCreator_ActionCanvas : MonoBehaviour
{
    public LevelCreator_Pipe Pipe {get; private set;}
    [SerializeField] private TextMeshProUGUI rowText, colText;
    [SerializeField] private GameObject changePipeCanvas;
    public void GetInitialInformation(LevelCreator_Pipe pipe)
    {
        this.Pipe = pipe;
        rowText.text = Pipe.Row.ToString();
        colText.text = Pipe.Col.ToString();
    }

    public void Close()
    {
        Destroy(this.gameObject);
    }

    public void ChangePipeType()
    {
        changePipeCanvas.SetActive(true);
    }

    public void RotatePipe()
    {
        Pipe.RotatePipe(90f);
    }

    public void RemovePipe()
    {
        //LevelCreator_ViewLevelInformation.Instance.RemovePipe(Pipe.Row,Pipe.Col);
        Pipe.ChangePipeType("empty");
    }

    public void CloseChangePipe()
    {
        changePipeCanvas.SetActive(false);
    }

    public void ChangePipeTypeByType(string type)
    {
        Pipe.ChangePipeType(type);
    }
}
