using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : IPipe
{
    public bool IsLight {get; private set;}
    public PipeType TypeOfPipe {get; private set;}
    public float Rotation {get; private set;}

    public Pipe(bool isLight, PipeType typeOfPipe, float rotation)
    {
        this.IsLight = isLight;
        this.TypeOfPipe = typeOfPipe;
        this.Rotation = rotation;
    }

    public void RotatePipe()
    {
        Rotation += 90f;
    }

    public void LightPipe()
    {
        IsLight = true;
    }

    public void UnlightPipe()
    {
        IsLight = false;
    }
}
