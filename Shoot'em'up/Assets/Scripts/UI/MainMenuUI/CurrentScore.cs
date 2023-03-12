using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public DataSaver save;
    [SerializeField] private Text text;

    private void Start()
    {
        ChangeScore();
        DataSaver.Change += ChangeScore;
        DataSaver.ChangeScin += ChangeScore1;
    }

    void ChangeScore()
    {
        text.text = save.data.scores.ToString();
    }
    
    void ChangeScore1(int a)
    {
        text.text = save.data.scores.ToString();
    }

    private void OnDestroy()
    {
        DataSaver.Change -= ChangeScore;
        DataSaver.ChangeScin -= ChangeScore1;
    }
}
