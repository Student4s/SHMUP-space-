using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagniteAsteroid : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float magnitePower;
    [SerializeField] private float rotationSpeed;
    private float rotation;

    [SerializeField] private Transform target;
    
    void Update()
    {
        rotation += Time.deltaTime*rotationSpeed;
        Vector3 offset = transform.position;
        offset += new Vector3(0, -1*(speed)*Time.deltaTime, 0);
        transform.position = offset;
        gameObject.transform.rotation = Quaternion.Euler(rotation,rotation,rotation);
        transform.position = Vector3.MoveTowards(transform.position, target.position, magnitePower * Time.deltaTime);
    }
    

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}
