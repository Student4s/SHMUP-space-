using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Image hp;
    [SerializeField] private Text score;
    
    private int totalScore=0;
    void Start()
    {
        Player.Score += ScoreChange;
        Player.Damaged += HPChange;
    }

    void HPChange(float hp, float maxHP)
    {
        float fill = hp / maxHP;
        this.hp.fillAmount = fill;
    }
    
    void ScoreChange(int scores)
    {
        totalScore = scores;
        score.text = totalScore.ToString();
    }
    
    private void OnDestroy()
    {
        Player.Score -= ScoreChange;
        Player.Damaged -= HPChange;
    }
}
