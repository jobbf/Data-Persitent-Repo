using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StoreDatas : MonoBehaviour
{
    public static StoreDatas Instance;

    public string chosenNameValue;
    public string bestScoreValue;
    public int pointsValue;

    [System.Serializable]
    class SaveData
    {
        public string bestScoreValue;
        public int pointsValue;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScoreValue = bestScoreValue;
        data.pointsValue = pointsValue;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreValue = data.bestScoreValue;
            pointsValue = data.pointsValue;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Instance != null");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
