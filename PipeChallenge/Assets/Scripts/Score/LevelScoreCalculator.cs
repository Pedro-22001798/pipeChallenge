using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoreCalculator : MonoBehaviour
{
    public int CalculateScore(ILevel level, float elapsedTime)
    {
        if (elapsedTime >= 120f)
        {
            // 2 minutes or more = 0 score
            return 0;
        }
        else if (elapsedTime >= 80f)
        {
            // 1 minute 20 seconds to 2 minutes = 1 score
            return 1;
        }
        else if (elapsedTime >= 30f)
        {
            // 30 seconds to 1 minute 20 seconds = 2 score
            return 2;
        }
        else
        {
            // Under 30 seconds = 3 score
            return 3;
        }
    }
}
