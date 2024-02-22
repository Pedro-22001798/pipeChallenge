using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformation
{
    public string Level {get; private set;}
    public int MaxMoves {get; private set;}

    public LevelInformation(string level, int maxMoves)
    {
        this.Level = level;
        this.MaxMoves = maxMoves;
    }
}

public class Levels : MonoBehaviour
{
    public List<LevelInformation> Maps {get; private set;}

    void Awake()
    {
        Maps = new List<LevelInformation>();

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));

        Maps.Add(new LevelInformation("light,-90\n" +
                 "normal,0\n" +
                 "end,90",15));

        Maps.Add(new LevelInformation("light,0,curve,180,empty,0\n" +
                      "empty,0,curve,90,curve,180\n" +
                      "empty,0,empty,0,end,180",15));

        Maps.Add(new LevelInformation("light,-90,empty,0,empty,0\n" +
                      "curve,0,normal,90,curve,180\n" +
                      "empty,0,empty,0,end,180",15));

        Maps.Add(new LevelInformation("light,0,normal,90,end,180\n" +
                      "light,0,normal,90,end,180\n" +
                      "light,0,normal,90,end,180",15));

        Maps.Add(new LevelInformation("empty,0,empty,0,empty,0,empty,0,end,90\n" +
                 "light,0,normal,90,normal,90,curve,90,normal,180\n" +
                 "empty,0,empty,0,empty,0,curve,90,curve,180\n" +
                 "empty,0,curve,90,curve,180,empty,0,light,270\n" +
                 "end,0,curve,90,curve,180,normal,0,curve,90",15));

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));

        Maps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                 "empty,0,normal,0,normal,0\n" +
                 "empty,0,end,180,end,180",15));
    }
}
