using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crashes;
    
    
    private void Start()
    {
        int num = PlayerPrefs.GetInt("Crashes");
        crashes.text = num.ToString();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("LastPlayedLevel") == 0)
        {
            PlayerPrefs.SetInt("LastPlayedLevel", 1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastPlayedLevel"));
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    
}
