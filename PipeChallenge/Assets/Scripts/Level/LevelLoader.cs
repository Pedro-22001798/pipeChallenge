using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private LevelController levelController;
    private FileDetection fileDetection;
    private FileReader fileReader;
    private AllLevels allLevels;
    private View view;
    public int CurrentLevel {get; private set;} = 1;
    List<string> allStringLevels;

    public void StartGame(LevelController levelController, FileDetection fileDetection, FileReader fileReader, AllLevels allLevels, View view)
    {
        this.levelController = levelController;
        this.fileDetection = fileDetection;
        this.fileReader = fileReader;
        this.allLevels = allLevels;
        this.view = view;
        allStringLevels = new List<string>();
        allStringLevels = fileDetection.GetLevelFiles();
        LoadNewLevel(CurrentLevel-1);
    }

    public void LoadNewLevel(int levelNumber)
    {
        ILevel level = fileReader.ReadFile(allStringLevels[levelNumber], levelNumber);
        view.BuildLevel(level);
    }
}
