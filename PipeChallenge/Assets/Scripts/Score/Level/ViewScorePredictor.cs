using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ViewScorePredictor : MonoBehaviour
{
    public static ViewScorePredictor Instance { get; private set; }
    [SerializeField] private Sprite fullStar, emptyStar;
    [SerializeField] private UnityEngine.UI.Image star1,star2,star3;
    [SerializeField] private Animator star1Animator, star2Animator, star3Animator;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateScorePrediction(int prediction)
    {
        if(prediction == 3)
        {

        }
        else if(prediction == 2)
        {
            star3Animator.SetTrigger("Hide");
        }
        else if(prediction == 1)
        {
            star2Animator.SetTrigger("Hide");
        }
        else
        {
            star1Animator.SetTrigger("Hide");
        }
    }
}
