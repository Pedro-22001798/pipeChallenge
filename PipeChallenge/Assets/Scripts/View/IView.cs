using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void BuildLevel(ILevel level);
    void LightPipe(SpriteRenderer sr);
    void UnlightPipe(SpriteRenderer sr);
    void RotatePipe(Transform pipeTransform, PipeClick pipe);
    void ClearLevel();
}
