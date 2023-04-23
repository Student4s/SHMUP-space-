using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
   [SerializeField] private GameObject loseMenu;
   
    void Awake()
    {
        Player.Die += OpenLoseMenu;
    }

    void OpenLoseMenu()
    {
        loseMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        Player.Die -= OpenLoseMenu;
    }
}
