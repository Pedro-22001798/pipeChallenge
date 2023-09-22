using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private View view;

    public int Score {get; private set;}

    void Start()
    {
        view.UpdateScoreText(Score);
    }

    public void AddScore(int newScore)
    {
        Score += newScore;
        view.UpdateScoreText(Score);
    }

    public void DefineScore(int newScore)
    {
        Score = newScore;
        view.UpdateScoreText(Score);
    }
}
