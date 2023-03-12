using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsWithSpeedup : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    private float currentAcceleration;
    [SerializeField] private float rotationSpeed;
    private float rotation;
    
    void Update()
    {
        rotation += Time.deltaTime*rotationSpeed;
        Vector3 offset = transform.position;
        offset += new Vector3(0, -1*(speed+currentAcceleration)*Time.deltaTime, 0);
        transform.position = offset;
        gameObject.transform.rotation = Quaternion.Euler(rotation,rotation,rotation);
        currentAcceleration += acceleration * Time.deltaTime;
    }
    
     
}
