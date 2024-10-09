using System;
using Zenject;

public sealed class ScorePresenter : IInitializable, IDisposable
{
    private readonly ScoreModel _scoreModel;
    private readonly EndWindowModel _endWindowModel;
    private readonly ScoreView _scoreView;


    public ScorePresenter(ScoreModel scoreModel, ScoreView scoreView, EndWindowModel endWindowModel)
    {
        _scoreModel = scoreModel;
        _scoreView = scoreView;
        _endWindowModel = endWindowModel;
    }

    public void Initialize()
    {
        _scoreModel.OnScoreChanged += ChangeScoreView;
        _scoreModel.OnContingEnd += ChangeEndWindowScoreValue;
    }

    public void Dispose()
    {
        _scoreModel.OnScoreChanged -= ChangeScoreView;
        _scoreModel.OnContingEnd -= ChangeEndWindowScoreValue;
    }

    public void ChangeScoreView()
    {
        _scoreView.ChangeScoreText(_scoreModel.Score.ToString());
    }

    public void ChangeEndWindowScoreValue()
    {
        _endWindowModel.CurrentScore = _scoreModel.Score;
    }
}
