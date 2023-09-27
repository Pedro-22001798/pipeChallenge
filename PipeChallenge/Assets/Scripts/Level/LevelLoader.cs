using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private StageController stageController;
    private LevelController levelController;
    private Levels levels;
    private FileReader fileReader;
    private AllLevels allLevels;
    private View view;
    public int CurrentLevel {get; private set;} = 0;
    private List<string> allStringLevels;

    public void StartGame(LevelController levelController, Levels levels, FileReader fileReader, AllLevels allLevels, View view)
    {
        this.levelController = levelController;
        this.levels = levels;
        this.fileReader = fileReader;
        this.allLevels = allLevels;
        this.view = view;
        allStringLevels = new List<string>();
        allStringLevels = levels.Maps;
        BuildAllLevels();
    }

    public void LoadNewLevel(int levelNumber)
    {
        stageController.LoadLevel(allLevels.GetLevel(levelNumber));
        view.BuildLevel(allLevels.GetLevel(levelNumber));
        CurrentLevel = allLevels.GetLevel(levelNumber).LevelNumber-1;
    }

    public void LoadNewLevel(ILevel level)
    {
        stageController.LoadLevel(level);
        view.BuildLevel(level);
        CurrentLevel = level.LevelNumber-1;
    }

    public void BuildAllLevels()
    {
        for(int i = 0; i < allStringLevels.Count; i++)
        {
            ILevel level = fileReader.ReadFile(allStringLevels[i], i+1);
        }
        if(saveManager.SaveExists)
            allLevels.SetLevelSavedInformation();
        stageController.LoadGame(allLevels.GetAllLevels());
        view.CreateLevelsUI(stageController.GetAllStageLevels(stageController.CurrentStage));
    }

    public void ChangeLevel(int newNumLevel)
    {
        CurrentLevel = newNumLevel;
    }

    public void UnlockNextLevel()
    {
        if(HowManyLevelsExist() > CurrentLevel+1)
        {
            ILevel level = allLevels.GetLevel(CurrentLevel+1);
            level.UnlockLevel();
        }
    }

    public int HowManyLevelsExist()
    {
        return allStringLevels.Count;
    }
}
