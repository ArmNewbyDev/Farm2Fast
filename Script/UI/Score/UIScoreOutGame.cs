using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;
using UnityEngine.SceneManagement;

public class UIScoreOutGame : MonoBehaviour
{
    [SerializeField] private GameObject FirstPlayerScore;
    [SerializeField] private GameObject SecondPlayerScore;
    [SerializeField] private GameObject HighScore;

    public void HighScoreOnBoardOpen()
    {
        HighScore.SetActive(true); 
    }
    public void HighScoreOnBoardClose()
    {
        HighScore.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.GameHasEnded == true && SceneManager.GetActiveScene().name == "EndScene")
        {
            ScoreManager.instance.HighScore();
            if (ScoreManager.instance.IsSoloPlay() == false)
            {
                FirstScoreOpen();
                SecondScoreOpen();
            }
            else
            {
                FirstScoreOpen();
                
            }
        }
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            HighScoreOnBoardOpen();
            FirstScoreClose();
            SecondScoreClose();
        }
        else
        {
            HighScoreOnBoardClose();
        }

    }

    public void ResetScoreBackToMenu()
    {
        //ScoreManager.instance.ResetScore();
        FirstScoreClose();
        SecondScoreClose();
    }
    public void FirstScoreOpen()
    {
       
            FirstPlayerScore.SetActive(true);
        
    }
    public void FirstScoreClose()
    {

            FirstPlayerScore.SetActive(false);

    }
    public void SecondScoreOpen()
    {

            SecondPlayerScore.SetActive(true);
        
    }
    public void SecondScoreClose()
    {

            SecondPlayerScore.SetActive(false);

    }
}
