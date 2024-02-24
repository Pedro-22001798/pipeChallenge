using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set;}
    [SerializeField] private GameObject mainMenu, game, options;
    [SerializeField] private Animator mainMenuAnimator, gameAnimator, optionsAnimator;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void OpenMainMenu()
    {

    }

    public void CloseMainMenu()
    {

    }

    public void OpenGame()
    {

    }

    public void CloseGame()
    {

    }

    public void OpenOptions()
    {

    }

    public void CloseOptions()
    {

    }
}
