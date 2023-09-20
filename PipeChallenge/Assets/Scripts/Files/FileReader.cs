using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    private AllLevels allLevels;

    public void StartGame(AllLevels allLevels)
    {
        this.allLevels = allLevels;
    }

    public ILevel ReadFile(string file, int currentLevel)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            List<IPipe> allPipes = new List<IPipe>();

            for (int row = 0; row < lines.Length; row++)
            {
                string[] cells = lines[row].Split(',');

                for (int col = 0; col < cells.Length; col += 2)
                {
                    string pipeType = cells[col];
                    float rotation = float.Parse(cells[col + 1]);
                    PipeType typeOfPipe = GetTypeOfPipe(pipeType);
                    IPipe pipe;
                    if (typeOfPipe == PipeType.light)
                    {
                        pipe = new Pipe(true, typeOfPipe,rotation,row,col);
                    }
                    else
                    {
                        pipe = new Pipe(false, typeOfPipe,rotation,row,col);
                    }

                    allPipes.Add(pipe);
                }
            }
            ILevel newLevel = new Level(currentLevel,allPipes);
            allLevels.CreateLevel(newLevel);
            return newLevel;
        }

        return null;
    }

    private PipeType GetTypeOfPipe(string pipe)
    {
        switch(pipe)
        {
            case "normal":
                return PipeType.normal;
            case "curve":
                return PipeType.curve;
            case "light":
                return PipeType.light;
            case "end":
                return PipeType.end;
        }

        return PipeType.normal;
    }
}
