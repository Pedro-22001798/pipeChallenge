using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    [SerializeField] private FileDetection fileDetection;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private LevelController levelController;
    [SerializeField] private FileReader fileReader;
    [SerializeField] private AllLevels allLevels;
    [SerializeField] private View view;

    void Start()
    {
        fileReader.StartGame(allLevels,view);
        levelLoader.StartGame(levelController,fileDetection,fileReader,allLevels, view);
    }
}
