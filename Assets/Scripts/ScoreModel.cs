using System;
using UnityEngine;
using Zenject;

public class ScoreModel : IInitializable, ITickable
{
    public event Action OnContingEnd;
    public event Action OnScoreChanged;

    public bool IsCounting { get => _isCounting; }

    public int Score
    {
        get => _score;
        set
        {
            if (value >= 0)
            {
                _score = value;
                OnScoreChanged?.Invoke();
            }
            else
            {
                Debug.LogWarning("[ScoreModel] Score value wasn't be less than zero!");
            }
        }
    }

    private int _score;

    private float _timelife;

    private int _multiplier = 23;

    private bool _isCounting;

    public void Initialize()
    {
        _isCounting = true;
    }

    public void Tick()
    {
        if (_isCounting)
        {
            UpdateScore();
        }
    }

    public void StopCounting()
    {
        _isCounting = false;
        OnContingEnd?.Invoke();
    }

    private void UpdateScore()
    {
        _timelife += Time.deltaTime;

        Score = TimelifeToScore();
    }

    private int TimelifeToScore() => (int)(_timelife * _multiplier);
}