using System;
using UnityEngine;
using System.IO;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;

    private string playerName;
    private string lastBestScorePlayerName;
    private int lastBestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSavedData();
    }

    public void StorePlayerName(string name)
    {
        Instance.playerName = name;
    }

    public void StoreLastBestScore(int bestScore, string playerName)
    {
        Instance.lastBestScore = bestScore;
        Instance.lastBestScorePlayerName = playerName;
    }

    public string GetPlayerName() => playerName;
    public int GetLastBestScore() => lastBestScore;
    public string GetLastBestScorePlayerName() => lastBestScorePlayerName;

    [Serializable]
    class SaveData
    {
        public string PlayerName;
        public int LastBestScore;
        public string LastBestScorePlayerName;
    }

    public void SaveDataToStorage()
    {
        SaveData data = new SaveData();
        data.PlayerName = playerName;
        data.LastBestScore = lastBestScore;
        data.LastBestScorePlayerName = lastBestScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.PlayerName;
            lastBestScore = data.LastBestScore;
            lastBestScorePlayerName = data.LastBestScorePlayerName;
        }
    }
}
