using System;
using Zenject;

public sealed class EndWindowPresenter : IInitializable, IDisposable
{
    private readonly EndWindowModel _endWindowModel;
    private readonly EndWindowView _endWindowView;

    public EndWindowPresenter(EndWindowModel endWindowModel, EndWindowView endW�indowView)
    {
        _endWindowModel = endWindowModel;
        _endWindowView = endW�indowView;
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
        _endWindowView.SetCurrentScore(_endWindowModel.CurrentScore.ToString());
    }

    public void ChangeHighcoreView()
    {
        _endWindowView.SetHighscore(_endWindowModel.Highscore.ToString());
    }
}
