using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;

public class LoadScene : MonoBehaviour
{

    public void BackToMenu()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        ScoreManager.instance.ResetScore();
        LoadingScreenController.instance.LoadNextScene("Menu");
    }
    public void BackToMenuFormEndScene()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        ScoreManager.instance.ResetScore();
        LoadingScreenController.instance.LoadNextScene("Menu");
    }

    public void PlayGame()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.LoadNextScene("Farm");
    }
    public void PlayGame2Player()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        ScoreManager.instance.MultiplayPlay();
        LoadingScreenController.instance.LoadNextScene("Farm2");
    }
    public void End()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.LoadNextScene("EndScene");
    }
    public void Credit()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.LoadNextScene("Credit");
    }
    public void Exit()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.ExitGame();
        Application.Quit();
    }

   

}
