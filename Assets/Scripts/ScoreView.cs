using TMPro;

public class ScoreView
{
    private TMP_Text _scoreText;

    public ScoreView(TMP_Text scoreText)
    {
        _scoreText = scoreText;
    }

    public void ChangeScoreText(string text)
    {
        _scoreText.text = text;
    }
}