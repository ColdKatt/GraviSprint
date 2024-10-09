[System.Serializable]
public struct ScoreData
{
    public int Highscore;

    public void Save()
    {
        var scoreModelSave = new SaveLoadSystem<ScoreData>(this);
        scoreModelSave.Save();
    }

    public ScoreData Load()
    {
        var scoreModelSave = new SaveLoadSystem<ScoreData>(this);
        var savedScoreModel = scoreModelSave.Load();

        return savedScoreModel;
    }
}
