using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMoves : MonoBehaviour
{
    public static ViewMoves Instance {get; private set;}
    [SerializeField] private GameObject addMoveFeedback;
    [SerializeField] private Transform moveFeedbackParent;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddMove()
    {
        GameObject feedback = Instantiate(addMoveFeedback,moveFeedbackParent);
        Destroy(feedback,2f);
    }
}
