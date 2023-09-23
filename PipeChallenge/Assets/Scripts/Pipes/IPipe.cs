using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPipe
{
    bool IsLight {get;}
    PipeType TypeOfPipe {get;}
    float StartRotation {get;}
    float CurrentRotation {get;}
    int Row {get;}
    int Col {get;}

    void Restart();
    void RotatePipe();
    void LightPipe();
    void UnlightPipe();

    void DefineConnections(List<IPipe> connections);
    List<IPipe> GetConnections();
}
