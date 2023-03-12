using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
   [SerializeField] private GameObject loseMenu;
   
   public delegate void SaveData();

   public static event SaveData Save;
    void Awake()
    {
        Player.Die += OpenLoseMenu;
    }

    void OpenLoseMenu()
    {
        loseMenu.SetActive(true);
        Save();
    }

    private void OnDestroy()
    {
        Player.Die -= OpenLoseMenu;
    }
}
