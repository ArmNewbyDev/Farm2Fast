using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyPlatformer
{
    public class Initializer : MonoBehaviour
    {
        private const string LOADING_SCREEN_NAME = "GamePlayManager";

        private void Awake()
        {
            // get a reference to the loading screen scene
            Scene loadingScreenScene = SceneManager.GetSceneByName(LOADING_SCREEN_NAME);
            // check if the scene is not loaded yet
            if (loadingScreenScene == null || !loadingScreenScene.isLoaded)
            {
                // load the loading screen scene
                SceneManager.LoadScene(LOADING_SCREEN_NAME, LoadSceneMode.Additive);
            }
        }
    }
}
