using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyPlatformer
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private int _score = 0;
        private int _score2 = 0;
        private int _highScore = 0;
        bool soloPlay = true;
        bool IsTaskComplete = false;

        [SerializeField] private UIScoreOutGame _game;
        [SerializeField] private UnityEvent<int> onScoreUpdatedFirst;
        [SerializeField] private UnityEvent<int> onScoreUpdatedSecond;
        [SerializeField] private UnityEvent<int> onHighScoreUpdated;

        protected override void Awake()
        {
            base.Awake();
            _highScore = SaveSystem.LoadHighScore();
            HighScore();
        }
        public void IsFinishTask(bool check)
        {
            if (check)
            {
                IsTaskComplete = true;
            }
            else IsTaskComplete = false;
            
        }

        public void AddFirstScore(int firstPlayer)
        {
            _score = firstPlayer;
            onScoreUpdatedFirst?.Invoke( firstPlayer );
            
        }
        public void AddSecondScore(int secondPlayer)
        {
            _score2 = secondPlayer;
            onScoreUpdatedSecond?.Invoke(secondPlayer);
            soloPlay = false;
        }
        public void MultiplayPlay()
        {
            soloPlay = false;
        }

        public bool IsSoloPlay()
        {
            if (soloPlay == true)
            {
                return true;
            }
            else { return false; }
        }

        public bool IsComplete()
        {
            return IsTaskComplete;
        }

        public string WhoWin()
        {
            if (_score>_score2)
            {
                return "FirstPlayer";
            }
            if (_score2>_score)
            {
                return "SecondPlayer";
            }
            else
            {
                return "Lose";
            }
        }

        public void ResetScore()
        {
            _score = 0;
            _score2 = 0; 
            soloPlay = true;
            IsTaskComplete = false;

        }

        public void HighScore()
        {
            CheckHighScore();
            onHighScoreUpdated?.Invoke(_highScore);
            SaveSystem.SaveHighScore(_highScore);
        }

        private int CheckHighScore()
        {
            if (_score > _highScore)
            {
                _highScore = _score;
            }
            if (_score2 > _highScore)
            {
                _highScore = _score2;
            }
            return _highScore;

        }
    }
}
