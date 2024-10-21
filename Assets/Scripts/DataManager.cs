using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public string playerName { get; private set; }
    public int m_HighScore { get; private set; }
    private List<HighScoreData> highScores = new List<HighScoreData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [System.Serializable]
    public class HighScoreData
    {
        public string name;
        public int score;
    }
    [System.Serializable]
    class HighScoreList
    {
        public List<HighScoreData> highScores;
        public HighScoreList(List<HighScoreData> highScores)
        {
            this.highScores = highScores;
        }
    }
    public void SaveHighScore()
    {
        List<HighScoreData> highScores = LoadHighScore();
        bool isUpdated = false;

        for (int i = 0; i < highScores.Count; i++)
        {
            if (playerName == highScores[i].name)
            {
                if (m_HighScore > highScores[i].score)
                {
                    highScores[i].score = m_HighScore;
                }
                isUpdated = true;
                break; // 找到并更新后退出循环
            }
        }

        if (!isUpdated)
        {
            HighScoreData data = new HighScoreData();
            data.name = playerName;
            data.score = m_HighScore;
            highScores.Add(data);
        }

        string json = JsonUtility.ToJson(new HighScoreList(highScores));
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }
    public List<HighScoreData> LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreList highScoreList = JsonUtility.FromJson<HighScoreList>(json);
            highScores = highScoreList.highScores;
            return highScores;
        }
        else
        {
            return new List<HighScoreData>();
        }
    }
    public void SetPlayerName(string name)
    {
        if (name == "")
        {
            playerName = "Mr.Nobody";
        }
        else
        {
            playerName = name;
        }
    }

    public void SetHighScore(int score)
    {
        m_HighScore = score;
        SaveHighScore();
    }
    public void ResetHighScore()
    {
        m_HighScore = 0;
    }
}
