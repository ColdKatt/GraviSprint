using System;
using Zenject;

public class EndWindowModel : IInitializable
{
    public event Action OnCurrentScoreChanged;
    public event Action OnHighscoreChanged;

    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            OnCurrentScoreChanged?.Invoke();

            if (_currentScore > _highscore)
            {
                HighScore = _currentScore;
            }
        }
    }

    public int HighScore
    {
        get => _highscore;
        set
        {
            _highscore = value;
            OnHighscoreChanged?.Invoke();
        }
    }

    private int _currentScore;
    private int _highscore;

    public void Initialize()
    {
        _currentScore = 0;
        _highscore = 0; // SaveData.Load()
    }
}
