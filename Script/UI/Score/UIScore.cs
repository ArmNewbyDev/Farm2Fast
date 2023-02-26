using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIScore : MonoBehaviour
{
    private int score = 0;
    public int _score => score;

        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScore(int currentscore)
        {
            _scoreText.text = $"Score : {currentscore}";
        }
    public void UpdateHighScore(int currentscore)
    {
        _scoreText.text = $"HighScore : {currentscore}";
    }
    public int CallScore()
    {
        if (_score==0)
        {
            return 0;
        }
        return _score;
    }
    public void AddScore(int currentscore)
    {
        score += currentscore;
        UpdateScore(score);
    }
    public void MinusScore(int currentscore)
    {
        score -= currentscore;
        UpdateScore(score);
    }
    public void EndReset()
    {
        score = 0;
    }
}


