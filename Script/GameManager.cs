using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;

public class GameManager : MonoBehaviour
{
    public static float TimeLeft;
    private static float setTime = 123f;

    public static bool GameHasEnded;

    public UIScore score1;
    public UIScore score2;

    void Awake()
    {
        GameHasEnded = false;
        TimeLeft = setTime;
    }



    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0f)
        {
            TimeLeft = 0f;
            if (!GameHasEnded)
            {
                
                EndGame();
            }
        }
    }

    void EndGame()
    {
        GameHasEnded=true;
        ScoreManager.instance.AddFirstScore(score1._score);
        
        if (score2 != null)
        {
            ScoreManager.instance.AddSecondScore(score2._score);
        }
        score1.EndReset();
        if (score2 != null)
        {
            score2.EndReset();
        }
        LoadingScreenController.instance.LoadNextScene("EndScene");
    }
}
