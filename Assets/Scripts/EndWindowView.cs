using UnityEngine;

public class EndWindowView
{
    private readonly string _showWindowAnimationName = "WindowAppear";

    private EndWindowData _endWindow;
    private Animator _windowAnimator;

    public EndWindowView(EndWindowData endWindowData, Animator windowAnimator)
    {
        _endWindow = endWindowData;
        _windowAnimator = windowAnimator;
    }

    public void SetCurrentScore(string score)
    {
        _endWindow.ScoreText.text = score;
    }

    public void SetHighscore(string score)
    {
        _endWindow.HighscoreText.text = score;
    }

    public void ShowWindow()
    {
        _windowAnimator.Play(_showWindowAnimationName);
    }
}
