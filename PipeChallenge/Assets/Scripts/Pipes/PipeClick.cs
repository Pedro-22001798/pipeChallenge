using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeClick : MonoBehaviour
{
    public IPipe Pipe {get; private set;}
    [SerializeField] private View view;
    private SpriteRenderer sr;
    [SerializeField] private bool isLight;
    private bool isRotating;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if(isLight)
            sr.color = Color.red;
        else
            sr.color = Color.white;
    }

    public void DefinePipe(IPipe pipe, View view)
    {
        this.Pipe = pipe;
        this.view = view;
        sr = GetComponent<SpriteRenderer>();
    }

    public void RotatePipe()
    {
        if(!isRotating)
        {
            Debug.Log("teste2");
            view.RotatePipe(this.transform,this);
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
            sr.color = Color.red;
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
            sr.color = Color.white;
        }
    }

    public void AllowRotation()
    {
        isRotating = false;
    }
}
