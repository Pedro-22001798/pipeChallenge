using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    private FileDetection fileDetection;
    private LevelLoader levelLoader;
    private LevelController levelController;
    private FileReader fileReader;
    private AllLevels allLevels;
    private IView view;

    void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        levelController = GetComponent<LevelController>();
        fileDetection = GetComponent<FileDetection>();
        allLevels = GetComponent<AllLevels>();
        fileReader = GetComponent<FileReader>();
        fileReader.StartGame(allLevels);
        levelLoader.StartGame(levelController,fileDetection,fileReader,allLevels);
    }
}
