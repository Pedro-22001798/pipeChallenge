using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    // Information about all levels
    private AllLevels allLevels;
    // Game view
    private View view;

    /// <summary>
    /// Method called at the start of the game to define the initial variables
    /// </summary>
    /// <param name="allLevels">Information about all levels</param>
    /// <param name="view">Game view</param>
    public void StartGame(AllLevels allLevels, View view)
    {
        this.allLevels = allLevels;
        this.view = view;
    }

    /// <summary>
    /// Method called to read a string and to create a new ILevel
    /// </summary>
    /// <param name="data">String being read</param>
    /// <param name="currentLevel">Current level of the one being created</param>
    /// <returns>Returns a created ILevel with the information given</returns>
    public ILevel ReadFile(string data, int currentLevel)
    {
        string[] lines = data.Split('\n');
        List<IPipe> allPipes = new List<IPipe>();

        for (int row = 0; row < lines.Length; row++)
        {
            string[] cells = lines[row].Split(',');

            for (int col = 0; col < cells.Length; col += 2)
            {
                string pipeType = cells[col];
                float rotation = 0; // Default rotation value

                // Check if there is a rotation value in the next cell
                if (col + 1 < cells.Length)
                {
                    rotation = float.Parse(cells[col + 1]);
                }
                int actualCol = col / 2 + 1;
                PipeType typeOfPipe = GetTypeOfPipe(pipeType);
                IPipe pipe;
                if (typeOfPipe == PipeType.light)
                {
                    pipe = new Pipe(true, typeOfPipe, rotation, row + 1, actualCol);
                }
                else
                {
                    pipe = new Pipe(false, typeOfPipe, rotation, row + 1, actualCol);
                }

                allPipes.Add(pipe);
            }
        }
        ILevel newLevel;
        if (currentLevel == 1)
            newLevel = new Level(currentLevel, allPipes, false, false);
        else
            newLevel = new Level(currentLevel, allPipes, false, true);
        
        allLevels.CreateLevel(newLevel);
        
        return newLevel;
    }

    /// <summary>
    /// Gets the pipe type according to the string provided
    /// </summary>
    /// <param name="pipe">String provided</param>
    /// <returns>Returns the pipe type</returns>
    private PipeType GetTypeOfPipe(string pipe)
    {
        switch(pipe)
        {
            case "normal":
                return PipeType.normal;
            case "curve":
                return PipeType.curve;
            case "mix":
                return PipeType.mix;
            case "light":
                return PipeType.light;
            case "end":
                return PipeType.end;
        }

        return PipeType.empty;
    }

    /// ---------------------------------------------------------------
    /// This is for ".pipes" maps created that did not load on android.
    /// ---------------------------------------------------------------
    /// 
    // public ILevel ReadFile(string file, int currentLevel)
    // {
    //     if (File.Exists(file))
    //     {
    //         string[] lines = File.ReadAllLines(file);
    //         List<IPipe> allPipes = new List<IPipe>();

    //         for (int row = 0; row < lines.Length; row++)
    //         {
    //             string[] cells = lines[row].Split(',');

    //             for (int col = 0; col < cells.Length; col += 2)
    //             {
    //                 string pipeType = cells[col];
    //                 float rotation = float.Parse(cells[col + 1]);
    //                 int actualCol = col / 2 + 1;
    //                 PipeType typeOfPipe = GetTypeOfPipe(pipeType);
    //                 IPipe pipe;
    //                 if (typeOfPipe == PipeType.light)
    //                 {
    //                     pipe = new Pipe(true, typeOfPipe,rotation,row+1,actualCol);
    //                 }
    //                 else
    //                 {
    //                     pipe = new Pipe(false, typeOfPipe,rotation,row+1,actualCol);
    //                 }

    //                 allPipes.Add(pipe);
    //             }
    //         }
    //         ILevel newLevel;
    //         if(currentLevel == 0)
    //             newLevel = new Level(currentLevel,allPipes);
    //         else
    //             newLevel = new Level(currentLevel,allPipes,false,true);
    //         allLevels.CreateLevel(newLevel);
    //         return newLevel;
    //     }

    //     return null;
    // }
}
