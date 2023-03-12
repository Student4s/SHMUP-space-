using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float maxHP=5f;
    [SerializeField] private float hp;
    [SerializeField] private int score;

    public delegate void PlayerDamaged(float hp, float maxHP);

    public static event PlayerDamaged Damaged;
    
    public delegate void ChangeScores(int score);

    public static event ChangeScores Score;
    
    public delegate void PlayerDie();

    public static event PlayerDie Die;
    void Start()
    {
        Enemy.EnemyDie += AddScore;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Death();
        Damaged(hp,maxHP);
    }

    void AddScore(int scores)
    {
        score += scores;
        Score(score);
    }
    void Death()
    {
        Time.timeScale = 0;
        Die();
    }

    private void OnDestroy()
    {
        Enemy.EnemyDie -= AddScore;
    }

}