using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeClick : MonoBehaviour
{
    public IPipe Pipe {get; private set;}
    private View view;
    private bool isRotating;
    private SpriteRenderer sr;
    private List<Transform> connections;

    public void DefinePipe(IPipe pipe, View view)
    {
        this.Pipe = pipe;
        this.view = view;
        sr = GetComponent<SpriteRenderer>();
        connections = new List<Transform>();
        if(IsLight())
            view.LightPipe(sr);
    }

    public void RotatePipe()
    {
        if(!isRotating)
        {
            view.RotatePipe(this.transform,this);
            Pipe.RotatePipe();
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
        connections = newConnections;
        foreach(Transform t in newConnections)
        {
            PipeClick pipeClick = t.GetComponent<PipeClick>();
            IPipe pipe = pipeClick.Pipe;
            pipeConnections.Add(pipe);
        }
        Pipe.DefineConnections(pipeConnections);
    }

    public List<Transform> GetConnections()
    {
        return connections;
    }

    public List<PipeClick> GetPipeConnections()
    {
        List<PipeClick> pipeClickConnections = new List<PipeClick>();
        foreach(Transform t in connections)
        {
            PipeClick pc = t.GetComponent<PipeClick>();
            pipeClickConnections.Add(pc);
        }
        return pipeClickConnections;
    }
}
