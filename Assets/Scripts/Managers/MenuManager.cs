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
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Level 1");
    }

    public void Continue()
    {
        GetComponent<AudioSource>().Play();

        if (PlayerPrefs.GetInt("LastPlayedLevel") == 1)
        {
            PlayerPrefs.SetInt("LastPlayedLevel", 2);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastPlayedLevel"));
    }

    public void Quit()
    {
        GetComponent<AudioSource>().Play();

        Debug.Log("Quit Game");
        Application.Quit();
    }

    
}
