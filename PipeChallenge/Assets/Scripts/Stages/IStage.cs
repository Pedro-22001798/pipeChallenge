using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStage
{
    public int CurrentStage {get;}
    public int MinStars {get;}
    public List<ILevel> CurrentLevels {get;}

    public void DefineLevels(List<ILevel> levels);
}
