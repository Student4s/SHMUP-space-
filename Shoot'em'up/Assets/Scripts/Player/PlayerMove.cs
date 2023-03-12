using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canMove = false;
    [SerializeField] private float roadWidthX;
    [SerializeField] private float roadWidthY;

    private Touch touch;

    void FixedUpdate()
    {
        if (canMove)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        Math.Clamp(transform.position.x + touch.deltaPosition.x * speed, -roadWidthX, roadWidthX),
                        Math.Clamp(transform.position.y + touch.deltaPosition.y * speed, -roadWidthY, roadWidthY),
                        transform.position.z);
                }
            }
        }
    }
}