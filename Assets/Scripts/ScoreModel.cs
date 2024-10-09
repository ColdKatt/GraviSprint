using System;
using UnityEngine;
using Zenject;

public class ScoreModel : IInitializable, ITickable
{
    public event Action OnContingEnd;
    public event Action OnScoreChanged;

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

    public int Highscore { get => _highscore.Value; }

    private int _score;
    private SavableVariable<string, int> _highscore;
    private SavableVariable<string, int> _lastScore;

    private float _timelife;

    private int _multiplier = 10;

    private bool _isCounting;

    public void Initialize()
    {
        _isCounting = true;

        _highscore ??= new("highscore", loadImmediately: true);
        _lastScore ??= new("lastscore", loadImmediately: true);

        Debug.Log($"H: {Highscore} {_highscore.Id}");
        Debug.Log($"L: {_lastScore.Value}");
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

    public void Save()
    {
        if (Highscore < _score)
        {
            _highscore.Value = _score;
        }

        _lastScore.Value = _score;
    }

    private void UpdateScore()
    {
        _timelife += Time.deltaTime;

        Score = TimelifeToScore();
    }

    private int TimelifeToScore() => (int)(_timelife * _multiplier);
}