using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;


    public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;

    }
    void Pause()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void PressPause()
    {
        if (GameIsPause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    
    private void Start()
    {
        Resume();
    }
}
