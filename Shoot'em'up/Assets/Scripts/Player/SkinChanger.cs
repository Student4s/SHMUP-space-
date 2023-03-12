using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private Material[] skins;
    private void Awake()
    {
        DataSaver.ChangeScin += ChangeSkin;
    }
    void ChangeSkin(int skinNumber)
    {
        gameObject.GetComponent<MeshRenderer>().material = skins[skinNumber];
    }
    private void OnDestroy()
    {
        DataSaver.ChangeScin -= ChangeSkin;
    }
}
