using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] ShowScoreEnd ui;

    public void ResetScoreGame()
    {
        ui.ResetGame();
    }
}
