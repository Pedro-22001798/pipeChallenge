using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePredictor : MonoBehaviour
{
    public static ScorePredictor Instance { get; private set; }
    private ILevel currentLevel;
    private int maxMoves;
    private int scoreFor0, scoreFor1, scoreFor2, scoreFor3;

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

    public void LoadLevel(ILevel currentLevel)
    {
        this.currentLevel = currentLevel;
        maxMoves = currentLevel.MaxMoves;
        DefineScoreForStars(maxMoves);
    }

    private void DefineScoreForStars(int maxMoves)
    {
        scoreFor3 = maxMoves - 5;
        scoreFor2 = maxMoves - 3;
        scoreFor1 = maxMoves;
    }

    public int PredictScore(int currentMoves)
    {
        if (currentMoves <= scoreFor3)
        {
            return 3;
        }
        else if (currentMoves <= scoreFor2) // No need to check if it's greater than scoreFor3; it's implied.
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}
