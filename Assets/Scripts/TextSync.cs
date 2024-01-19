using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TextSync
{
    private static TMP_Text s_currentScoreText;
    private static TMP_Text s_HighscoreText;

    [Inject]
    private void Construct([Inject(Id = "Current")] TMP_Text currentText, [Inject(Id = "Highscore")] TMP_Text highscoreText)
    {
        Debug.Log("TextSync");
        s_currentScoreText = currentText;
        s_HighscoreText = highscoreText;
    }

    public static void SyncCurrent(string syncText)
    {
        s_currentScoreText.text = syncText;
    }

    public static void SyncHighscore(string syncText)
    {
        s_HighscoreText.text = syncText;
    }
}
