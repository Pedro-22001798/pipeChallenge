using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private View view;
    
    public int Score {get; private set;}

    public void AddScore(int newScore)
    {
        Score += newScore;
    }

    public void DefineScore(int newScore)
    {
        Score = newScore;
    }
}
