using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private PipeClick PipeClick;

    void Start()
    {
        PipeClick = GetComponent<PipeClick>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        PipeClick colPipe = col.transform.GetComponent<PipeClick>();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        PipeClick colPipe = col.transform.GetComponent<PipeClick>();   
    }
}
