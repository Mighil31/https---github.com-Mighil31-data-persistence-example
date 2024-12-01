using UnityEngine;
using System.IO;
using System;

public class Persistance : MonoBehaviour
{
    public static Persistance Instance;
    public string playerName = "Player";
    public int score = 0;
    public string highScorePlayerName;
    public int highScore = 0;

    private void Awake()
    {
        // start of new code
      if (Instance != null)
      {
          Destroy(gameObject);
          return;
      }
      // end of new code

      Instance = this;
      DontDestroyOnLoad(gameObject);
      LoadData();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.playerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data != null) {
                highScorePlayerName = data.playerName;
                highScore = data.highScore;
            }

        }
    }
}
