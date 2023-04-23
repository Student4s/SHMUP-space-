using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public delegate void LoadScin(int scinNumber);

    public static event LoadScin ChangeScin;
    
    public delegate void ChangeScore();

    public static event ChangeScore Change;

    public Data data;
    private void Awake()
    {
        Load();
        Enemy.EnemyDie += AddScore;
    }

    public void Load()
    {
        data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.streamingAssetsPath + "Save.json"));
        if (data != null)
            ChangeScin(data.currentScinNumber);

    }

    public void Save()
    {
        File.WriteAllText(Application.streamingAssetsPath + "Save.json", JsonUtility.ToJson(data));
    }
    void AddScore(int score)
    {
        data.scores += score;
        Save();
    }

    public void SetCurrentScin(int number)
    {
        data.currentScinNumber = number;
    }

    public void ChangeScores()
    {
        Change();
    }
    private void OnDestroy()
    {
        Enemy.EnemyDie -= AddScore;
    }

    [Serializable]
    public class Data
    {
        public int scores;
        public int currentScinNumber = 0;
        public bool[] availableScins = new bool[6];
    }
}