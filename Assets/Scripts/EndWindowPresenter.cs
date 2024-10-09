using System;
using Zenject;

public sealed class EndWindowPresenter : IInitializable, IDisposable
{
    private readonly EndWindowModel _endWindowModel;
    private readonly EndWindowView _endWñindowView;

    public EndWindowPresenter(EndWindowModel endWindowModel, EndWindowView endWñindowView)
    {
        _endWindowModel = endWindowModel;
        _endWñindowView = endWñindowView;
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
        _endWñindowView.SetCurrentScore(_endWindowModel.CurrentScore.ToString());
    }

    public void ChangeHighcoreView()
    {
        _endWñindowView.SetHighscore(_endWindowModel.HighScore.ToString());
    }
}
