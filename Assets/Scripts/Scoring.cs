using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Scoring : ITickable
{
    private TMP_Text _scoreText;
    private static int s_score;
    private static int s_highscore;
    private float _timelife;

    private int _multiplier = 10;

    public static int Score
    {
        get
        {
            return s_score;
        }
        set
        {
            s_score = value;
            Highscore = value;
            GameRoot.ReCalculateParameters();
        }
    }

    public static int Highscore
    {
        get
        {
            return s_highscore;
        }
        set
        {
            if (value > Highscore)
            {
                s_highscore = value;
            }
        }
    }

    public void Tick()
    {
        UpdateScore();
    }

    public Scoring(TMP_Text scoreText)
    {
        _scoreText = scoreText;
    }

    private void UpdateScore()
    {
        if (GameRoot.PlayerState is Alive)
        {
            _timelife += Time.deltaTime; 
        }
        Score = TimelifeToScore();
        _scoreText.text = Score.ToString();
        //_scoreText.text = 
    }

    private int TimelifeToScore() => (int)(_timelife * _multiplier);
}
