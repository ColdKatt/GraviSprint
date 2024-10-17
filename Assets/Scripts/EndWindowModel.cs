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

            // refactoring 
            if (_currentScore > _savedHighscore.Value)
            {
                Highscore = _savedHighscore.Value = _currentScore;
            }
            else
            {
                Highscore = _savedHighscore.Value;
            }
        }
    }

    public int Highscore
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
    private SavableVariable<int> _savedHighscore;

    public void Initialize()
    {
        _savedHighscore ??= new("highscore", loadImmediately: true);

        OnHighscoreChanged?.Invoke();

        _currentScore = 0;
    }
}
