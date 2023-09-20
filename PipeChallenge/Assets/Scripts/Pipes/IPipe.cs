using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPipe
{
    bool IsLight {get;}
    PipeType TypeOfPipe {get;}

    void LightPipe();
    void UnlightPipe();
}
