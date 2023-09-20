using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private LevelController levelController;
    private FileDetection fileDetection;
    private FileReader fileReader;
    public int CurrentLevel {get; private set;} = 1;
    List<string> allLevels;

    public void StartGame(LevelController levelController, FileDetection fileDetection, FileReader fileReader)
    {
        this.levelController = levelController;
        this.fileDetection = fileDetection;
        this.fileReader = fileReader;
        allLevels = new List<string>();
        allLevels = fileDetection.GetLevelFiles();
        LoadNewLevel(CurrentLevel-1);
    }

    public void LoadNewLevel(int levelNumber)
    {
        fileReader.ReadFile(allLevels[levelNumber]);
    }
}
