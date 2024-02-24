using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string SAVE_FILENAME = "save.dat";

    private string _saveFilePath;

    public AllLevels allLevels;
    public PlayerScore playerScore;
    public PlayerXPManager playerXP;

    [System.Serializable]
    private struct GameSaveData
    {
        public AllLevels.SaveData allLevelsSaveData;
        public PlayerScore.SaveData playerScoreSaveData;
        public PlayerXPManager.SaveData playerXPSaveData;
    }

    public bool SaveExists {get; private set;}

    void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/" + SAVE_FILENAME;
        //LoadGame();
    }

    public void SaveGame()
    {
        GameSaveData saveData;
        saveData.allLevelsSaveData = allLevels.GetSaveData();
        saveData.playerScoreSaveData = playerScore.GetSaveData();
        saveData.playerXPSaveData = playerXP.GetSaveData();
        string jsonSaveData = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_saveFilePath, jsonSaveData);
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
        {
            SaveExists = true;
            string jsonSaveData = File.ReadAllText(_saveFilePath);
            GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(jsonSaveData);
            allLevels.LoadSaveData(saveData.allLevelsSaveData);
            playerScore.LoadSaveData(saveData.playerScoreSaveData);
            playerXP.LoadSaveData(saveData.playerXPSaveData);
        }
        else
        {
            SaveExists = false;
            allLevels.CreateSaveLists();
            playerScore.DefineScore(0);
            playerXP.ResetInfomartion();
        }
    }
}
