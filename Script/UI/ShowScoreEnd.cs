using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyPlatformer;

public class ShowScoreEnd : MonoBehaviour
{
    [SerializeField] private GameObject Win1;
    [SerializeField] private GameObject Win2;
    [SerializeField] private GameObject Lose;

    private void Start()
    {
        
        
            if (ScoreManager.instance.WhoWin() == "FirstPlayer"|| ScoreManager.instance.IsComplete())
            {
                Win1.SetActive(true);
                SoundManager.instance.Play(SoundManager.SoundName.Win);
            SoundManager.instance.Play(SoundManager.SoundName.WinFireWork);
            }
            if (!ScoreManager.instance.IsSoloPlay())
            {
                if (ScoreManager.instance.WhoWin() == "SecondPlayer")
                {
                    Win2.SetActive(true);
                    SoundManager.instance.Play(SoundManager.SoundName.Win);
                SoundManager.instance.Play(SoundManager.SoundName.WinFireWork);
                }
            }
            if (ScoreManager.instance.WhoWin() == "Lose" || !ScoreManager.instance.IsComplete())
            {
                Lose.SetActive(true);
                SoundManager.instance.Play(SoundManager.SoundName.Lose);
            }
                
        
    }

    public void ResetGame()
    {
        Win1.SetActive(false);
        Win2.SetActive(false);
        Lose.SetActive(false);
    }
}
