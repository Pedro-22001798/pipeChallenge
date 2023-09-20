using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : IPipe
{
    public bool IsLight {get; private set;}
    public PipeType TypeOfPipe {get; private set;}

    public Pipe(bool isLight, PipeType typeOfPipe)
    {
        this.IsLight = isLight;
        this.TypeOfPipe = typeOfPipe;
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
