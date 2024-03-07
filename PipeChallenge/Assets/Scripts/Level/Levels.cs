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
    public List<LevelInformation> HardCoreMaps {get; private set;}
    public List<LevelInformation> DailyMaps {get; private set;}

    void Awake()
    {
        CreateNormalMaps();
        CreateHardCoreMaps();
        CreateDailyMaps();
    }

    private void CreateNormalMaps()
    {
        Maps = new List<LevelInformation>();

        Maps.Add(new LevelInformation("light,270,curve,90,normal,0,mix,0\n" +
                    "normal,90,empty,0,empty,0,normal,90\n" +
                    "normal,180,curve,270,empty,0,end,90\n" +
                    "mix,0,normal,90,normal,0,curve,180",15));

        Maps.Add(new LevelInformation("light,0,curve,270,normal,0,curve,0\n" +
                    "curve,0,curve,0,curve,270,normal,0\n" +
                    "curve,0,mix,90,curve,180,normal,90\n" +
                    "mix,0,curve,180,curve,0,end,0",20));

        Maps.Add(new LevelInformation("light,270,curve,0,curve,0,end,270\n" +
                    "curve,0,curve,0,mix,0,normal,0\n" +
                    "normal,90,curve,0,normal,0,curve,0\n" +
                    "end,90,mix,0,normal,0,light,180",15));

        Maps.Add(new LevelInformation("light,270,end,0,light,270\n" +
                    "normal,0,mix,0,curve,0\n" +
                    "normal,0,curve,0,normal,0\n" +
                    "end,90,curve,0,end,180",12));

        Maps.Add(new LevelInformation("empty,0,light,270,empty,0\n" +
                    "curve,0,curve,90,mix,0\n" +
                    "mix,0,normal,0,normal,0\n" +
                    "curve,0,end,0,curve,0",10));

        Maps.Add(new LevelInformation("empty,0,curve,0,curve,270,end,180\n" +
                    "empty,0,curve,90,curve,180,normal,0\n" +
                    "light,0,mix,0,curve,90,curve,180",15));

        Maps.Add(new LevelInformation("light,0,curve,0,mix,0,end,180\n" +
                    "light,0,curve,90,mix,0,end,180\n" +
                    "light,0,normal,90,curve,0,end,180",12));

        Maps.Add(new LevelInformation("end,0,curve,0,end,180\n" +
                    "curve,0,mix,0,curve,0\n" +
                    "empty,0,light,90,empty,0",6));

        Maps.Add(new LevelInformation("empty,0,mix,0,mix,0\n" +
                    "empty,0,normal,0,normal,90\n" +
                    "light,0,curve,0,end,0",10));

        Maps.Add(new LevelInformation("curve,0,normal,90,curve,0\n" +
                    "curve,90,end,180,mix,0\n" +
                    "light,0,normal,0,curve,0",8));

        Maps.Add(new LevelInformation("curve,270,end,180,empty,0\n" +
                    "curve,90,mix,0,curve,0\n" +
                    "end,90,light,90,end,180", 10));

        Maps.Add(new LevelInformation("light,0,curve,0,empty,0\n" +
                    "empty,0,mix,0,end,0\n" +
                    "empty,0,curve,0,end,0",8));

        Maps.Add(new LevelInformation("light,0,curve,270,empty,0,curve,0,end,270\n" +
                    "empty,0,normal,0,curve,0,normal,90,curve,180\n" +
                    "empty,0,curve,0,mix,180,curve,270,empty,0\n" +
                    "empty,0,empty,0,normal,0,curve,180,curve,270\n" +
                    "light,0,normal,0,curve,270,empty,0,end,90",20));

        Maps.Add(new LevelInformation("light,0,empty,0,empty,0\n" +
                    "curve,0,normal,0,empty,0\n" +
                    "empty,0,curve,0,end,0",14));

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

    private void CreateHardCoreMaps()
    {
        HardCoreMaps = new List<LevelInformation>();

        HardCoreMaps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                        "empty,0,normal,0normal,0\n" +
                        "empty,0,end,180,end,180",10));
    }

    private void CreateDailyMaps()
    {
        DailyMaps = new List<LevelInformation>();

        DailyMaps.Add(new LevelInformation("light,0,mix,0,curve,90\n" +
                    "empty,0,normal,0normal,0\n" +
                    "empty,0,end,180,end,180",10));
    }    
}
