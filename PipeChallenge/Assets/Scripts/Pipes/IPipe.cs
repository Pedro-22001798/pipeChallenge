using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPipe
{
    bool IsLight {get;}
    PipeType TypeOfPipe {get;}
    float Rotation {get;}
    int Row {get;}
    int Col {get;}

    void LightPipe();
    void UnlightPipe();
}
