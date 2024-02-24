using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private View view;

    public int Score {get; private set;}

    [System.Serializable]
    public struct SaveData
    {
        public int         savePlayerScore;
    }

    void Start()
    {
        view.UpdateScoreText(Score);
    }

    public void AddScore(int newScore)
    {
        Score += newScore;
        PlayerXPManager.Instance.AddXP(newScore);
        view.UpdateScoreText(Score);
    }

    public void DefineScore(int newScore)
    {
        Score = newScore;
        view.UpdateScoreText(Score);
    }

    public SaveData GetSaveData()
    {
        SaveData saveData;
        saveData.savePlayerScore = Score;

        return saveData;
    }

    public void LoadSaveData(SaveData saveData)
    {
        Score = saveData.savePlayerScore;
        DefineScore(Score);
    }
}
