using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public int _highScore = 0;

    public HighScoreData(int highScore)
    {
        _highScore = highScore;
    }
}
