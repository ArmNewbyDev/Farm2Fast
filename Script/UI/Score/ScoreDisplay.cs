using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyPlatformer
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        

        public void UpdateScore(int currentscore)
        {
            _scoreText.text = $"Score : {currentscore}";
        }


    }
}
