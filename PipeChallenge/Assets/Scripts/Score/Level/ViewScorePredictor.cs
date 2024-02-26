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
            star1.sprite = fullStar;
            star2.sprite = fullStar;
            star3.sprite = fullStar;
        }
        else if(prediction == 2)
        {
            star1.sprite = fullStar;
            star2.sprite = fullStar;
            star3.sprite = emptyStar;
        }
        else
        {
            star1.sprite = fullStar;
            star2.sprite = emptyStar;
            star3.sprite = emptyStar;
        }
    }
}
