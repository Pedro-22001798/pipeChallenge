using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void LightPipe();
    void RotatePipe(Transform pipeTransform, PipeClick pipe);
}
