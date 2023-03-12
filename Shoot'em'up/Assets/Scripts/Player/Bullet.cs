using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifeTime = 1f;
    private float _currentLifeTime;
    [SerializeField] private float damage = 1f;

    public bool isActive;
    public int bulletID { get; private set; }

    void Start()
    {
        _currentLifeTime = lifeTime;
    }
    
    void Update()
    {
        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <= 0)
        {
            _currentLifeTime = lifeTime;
            SetActive(false);
        }
        transform.Translate(0, 0, -1 * speed * Time.deltaTime);
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
        isActive = state;
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            obj.GetComponent<Enemy>().GetDamage(damage);
            Debug.Log("Get");
        }
        SetActive(false);
    }
}