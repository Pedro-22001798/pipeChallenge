using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<string> Maps {get; private set;}

    void Awake()
    {
        Maps = new List<string>();

        Maps.Add("light,-90\n" +
                 "normal,0\n" +
                 "end,90");

        Maps.Add("light,0,curve,180,empty,0\n" +
                      "empty,0,curve,90,curve,180\n" +
                      "empty,0,empty,0,end,180");

        Maps.Add("light,-90,empty,0,empty,0\n" +
                      "curve,0,normal,90,curve,180\n" +
                      "empty,0,empty,0,end,180");

        Maps.Add("light,0,normal,90,end,180\n" +
                      "light,0,normal,90,end,180\n" +
                      "light,0,normal,90,end,180");

        Maps.Add("empty,0,empty,0,empty,0,empty,0,end,90\n" +
                 "light,0,normal,90,normal,90,curve,90,normal,180\n" +
                 "empty,0,empty,0,empty,0,curve,90,curve,180\n" +
                 "empty,0,curve,90,curve,180,empty,0,light,270\n" +
                 "end,0,curve,90,curve,180,normal,0,curve,90");
    }
}
