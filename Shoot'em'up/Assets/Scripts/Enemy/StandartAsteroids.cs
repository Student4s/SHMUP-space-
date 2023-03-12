using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartAsteroids : Enemy
{
    private float damage = 1f;
    public int asteroidType;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private float rotation;

    [SerializeField] private Transform target;
    [SerializeField] private float magnitePower;

    [SerializeField] private float acceleration;
    private float currentAcceleration;
    private float screenEnd = 3f;

    [SerializeField] private Material[] skins;


    void Update()
    {
        rotation += Time.deltaTime * rotationSpeed;
        Vector3 offset = transform.position;
        offset += new Vector3(0, -1 * (speed + currentAcceleration) * Time.deltaTime, 0);
        transform.position = offset;
        gameObject.transform.rotation = Quaternion.Euler(rotation, rotation, rotation);

        transform.position = Vector3.MoveTowards(transform.position, target.position, magnitePower * Time.deltaTime);
        currentAcceleration += acceleration * Time.deltaTime;

        if (transform.position.y < -screenEnd)
        {
            currentAcceleration = 0;
            SetActive(false);
        }
           
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetParameter(float speed, float rotationSpeed, Transform target, float magnitePower, float acceleration,
        int asteroidType)
    {
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.target = target;
        this.magnitePower = magnitePower;
        this.acceleration = acceleration;
        this.asteroidType = asteroidType;
    }

    public override void Death()
    {
        base.Death();
        currentAcceleration = 0;
    }

    public void SetMaterial(int index)
    {
        gameObject.GetComponent<MeshRenderer>().material = skins[index];
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Death();
        }
    }
}