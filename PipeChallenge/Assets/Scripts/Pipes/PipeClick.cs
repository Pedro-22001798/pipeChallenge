using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeClick : MonoBehaviour
{
    public IPipe Pipe {get; private set;}
    private View view;
    private SpriteRenderer sr;
    private bool isRotating;

    public void DefinePipe(IPipe pipe, View view)
    {
        this.Pipe = pipe;
        this.view = view;
        sr = GetComponent<SpriteRenderer>();
        ChangeColor(Pipe.IsLight);
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
        return Pipe.IsLight;
    }

    public void LightPipe()
    {
        if(!Pipe.IsLight)
        {
            Pipe.LightPipe();
            ChangeColor(Pipe.IsLight);
        }
    }

    public void UnlightPipe()
    {
        if(Pipe.IsLight)
        {
            Pipe.UnlightPipe();
            ChangeColor(Pipe.IsLight);
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
