using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeClick : MonoBehaviour
{
    public IPipe Pipe {get; private set;}
    private View view;
    private SpriteRenderer sr;
    private bool isLight;
    private bool isRotating;

    public void DefinePipe(IPipe pipe, View view, bool isLight)
    {
        this.Pipe = pipe;
        this.view = view;
        this.isLight = isLight;
        sr = GetComponent<SpriteRenderer>();
        ChangeColor(isLight);
    }

    public void RotatePipe()
    {
        if(!isRotating)
        {
            view.RotatePipe(this.transform,this);
            isRotating = true;
        }
    }

    public bool IsLight()
    {
        //return Pipe.IsLight;
        return isLight;
    }

    public void LightPipe()
    {
        // if(!Pipe.IsLight)
        // {
        //     Pipe.LightPipe();
        // }
        if(!isLight)
        {
            isLight = true;
            ChangeColor(isLight);
        }
    }

    public void UnlightPipe()
    {
        // if(Pipe.IsLight)
        // {
        //     Pipe.UnlightPipe();
        // }
        if(isLight)
        {
            isLight = false;
            ChangeColor(isLight);
        }
    }

    public void ChangeColor(bool light)
    {
        if(light)
            sr.color = Color.red;
        else
            sr.color = Color.white;
    }

    public void AllowRotation()
    {
        isRotating = false;
    }
}
