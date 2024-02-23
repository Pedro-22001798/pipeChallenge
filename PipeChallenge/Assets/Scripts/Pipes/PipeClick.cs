using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeClick : MonoBehaviour
{
    public IPipe Pipe {get; private set;}
    private View view;
    private bool isRotating;
    private SpriteRenderer sr;
    private List<PipeClick> connections;

    public void DefinePipe(IPipe pipe, View view)
    {
        this.Pipe = pipe;
        this.view = view;
        sr = GetComponent<SpriteRenderer>();
        connections = new List<PipeClick>();
        if(IsLight())
            view.LightPipe(sr);
    }

    public void RotatePipe(bool isBlock = false)
    {
        if(!isRotating)
        {
            if(!isBlock)
            {
                if(MovesManager.Instance.HasMoreMoves())
                {
                    view.RotatePipe(this.transform,this);
                    Pipe.RotatePipe();
                    MovesManager.Instance.AddMove();
                }
            }
            else
            {
                view.BlockRotation(this.transform,this);
            }
            isRotating = true;
        }
    }

    public bool IsLight()
    {
        return Pipe.IsLight;
    }

    public void LightPipe()
    {
        if(!Pipe.IsLight)
        {
            Pipe.LightPipe();
            view.LightPipe(sr);
            foreach(PipeClick pc in connections)
            {
                pc.LightPipe();
            }
        }
    }

    public void UnlightPipe()
    {
        if(Pipe.IsLight)
        {
            Pipe.UnlightPipe();
            view.UnlightPipe(sr);
        }
    }

    public void AllowRotation()
    {
        isRotating = false;
    }

    public void DefineConnections(List<Transform> newConnections)
    {
        List<IPipe> pipeConnections = new List<IPipe>();
        connections = new List<PipeClick>();
        foreach(Transform t in newConnections)
        {
            PipeClick pipeClick = t.GetComponent<PipeClick>();
            connections.Add(pipeClick);
            IPipe pipe = pipeClick.Pipe;
            pipeConnections.Add(pipe);
        }
        Pipe.DefineConnections(pipeConnections);
    }

    public List<PipeClick> GetConnections()
    {
        return connections;
    }
}
