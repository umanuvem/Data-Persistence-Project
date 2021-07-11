using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string bestScoreName;
    public int bestScorePoints;
    public string c_Name;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        bestScorePoints = 0;
        LoadScore();
    }

    public void SetBestScore(int points)
    {
        if (points > bestScorePoints)
        {
            bestScoreName = c_Name;
            bestScorePoints = points;
        }
    }


    [System.Serializable]
    class SaveData
    {
        public string name;
        public int points;
    }
    
    public void SaveScore()
    {
        SaveData saveScore = new SaveData();
        saveScore.name = bestScoreName;
        saveScore.points = bestScorePoints;

        string json = JsonUtility.ToJson(saveScore);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        SaveData saveScore = new SaveData();
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveScore = JsonUtility.FromJson<SaveData>(json);
            bestScoreName = saveScore.name;
            bestScorePoints = saveScore.points;
        }
    }
}
