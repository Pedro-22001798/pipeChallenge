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

    void RotatePipe();
    void LightPipe();
    void UnlightPipe();

    void DefineConnections(List<IPipe> connections);
    List<IPipe> GetConnections();
}
