using System;
using Zenject;

public sealed class EndWindowPresenter : IInitializable, IDisposable
{
    private readonly EndWindowModel _endWindowModel;
    private readonly EndWindowView _endW�indowView;

    public EndWindowPresenter(EndWindowModel endWindowModel, EndWindowView endW�indowView)
    {
        _endWindowModel = endWindowModel;
        _endW�indowView = endW�indowView;
    }

    public void Initialize()
    {
        _endWindowModel.OnCurrentScoreChanged += ChangeCurrentScoreView;
        _endWindowModel.OnHighscoreChanged += ChangeHighcoreView;
    }

    public void Dispose()
    {
        _endWindowModel.OnCurrentScoreChanged -= ChangeCurrentScoreView;
        _endWindowModel.OnHighscoreChanged -= ChangeHighcoreView;
    }

    public void ChangeCurrentScoreView()
    {
        _endW�indowView.SetCurrentScore(_endWindowModel.CurrentScore.ToString());
    }

    public void ChangeHighcoreView()
    {
        _endW�indowView.SetHighscore(_endWindowModel.HighScore.ToString());
    }
}
