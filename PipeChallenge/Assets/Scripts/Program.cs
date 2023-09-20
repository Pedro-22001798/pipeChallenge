using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    private FileDetection fileDetection;
    private LevelLoader levelLoader;
    private LevelController levelController;
    private FileReader fileReader;
    private IView view;

    void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        levelController = GetComponent<LevelController>();
        fileDetection = GetComponent<FileDetection>();
        fileReader = GetComponent<FileReader>();
        levelLoader.StartGame(levelController,fileDetection,fileReader);
    }
}
