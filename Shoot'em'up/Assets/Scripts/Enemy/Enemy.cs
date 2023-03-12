using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected int scores;

    protected float _currenthp;
    public bool isActive;

    public delegate void Die(int score);

    public static event Die EnemyDie;
    
    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
            Death();
    }
    
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
        isActive = state;
        _currenthp = hp;
    }

    virtual public void Death()
    {
        SetActive(false);
        EnemyDie(scores);
    }
  
}