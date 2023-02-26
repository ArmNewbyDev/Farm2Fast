using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyPlatformer
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private string _firstSceneName;

        public void StartGame()
        {
            SceneManager.LoadScene(_firstSceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
