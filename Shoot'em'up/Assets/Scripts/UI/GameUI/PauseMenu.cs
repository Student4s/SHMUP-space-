using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public delegate void SaveData();

    public static event SaveData Save;
    public void OpenMenu()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }
    
    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        Save();
        SceneManager.LoadScene(0);
    }
}
