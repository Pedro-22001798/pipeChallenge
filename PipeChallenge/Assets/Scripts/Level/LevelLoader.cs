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
    public int CurrentLevel {get; private set;} = 0;
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
        BuildAllLevels();
        LoadNewLevel(CurrentLevel);
        levelController.LoadNewLevel(allLevels.GetLevel(CurrentLevel));
    }

    public void LoadNewLevel(int levelNumber)
    {
        view.BuildLevel(allLevels.GetLevel(levelNumber));
    }

    public void BuildAllLevels()
    {
        for(int i = 0; i < allStringLevels.Count; i++)
        {
            ILevel level = fileReader.ReadFile(allStringLevels[i], i+1);
        }
    }

    public void ChangeLevel(int newNumLevel)
    {
        CurrentLevel = newNumLevel;
    }
}
