using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer meshRednder;
    private Vector2 meshOffset;

    void Start()
    {
        meshOffset = meshRednder.sharedMaterial.mainTextureOffset;
    }


    void Update()
    {
        float x = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(x, meshOffset.y);
        meshRednder.sharedMaterial.mainTextureOffset = offset;
    }

    private void OnDisable()
    {
        meshRednder.sharedMaterial.mainTextureOffset = meshOffset;
    }
}
