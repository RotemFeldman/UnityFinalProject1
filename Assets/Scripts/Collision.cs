using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Build.Content;
using System.Threading;

public class Collision : MonoBehaviour
{
    [SerializeField] UIManager UI;
    [SerializeField] AudioClip endAudio;
    [SerializeField] AudioClip hitAudio;

    AudioSource audioSource;
    bool _playerCrashed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                LevelDone();
                break;
            case "Coin":
                UI.PickedUpCoin();
                Destroy(collision.gameObject);
                break;
            case "Start":
                break; 
            default:
                PlayerCrash();              
                break;
        }
    }

    void PlayerCrash()
    {
        GetComponent<Movement>().enabled = false;

        audioSource.PlayOneShot(hitAudio);

        AddCrash();
        Invoke("ReloadLevel", 1);
    }

    void LevelDone()
    {
        GetComponent<Movement>().enabled = false;

        audioSource.PlayOneShot(endAudio);

        if (UI.coinsAmount == UI.coinsInLevel)
        Invoke("LoadNextLevel", 1);
        else
        {
            Invoke("ReloadLevel", 1);
        }
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextLevel()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;       

        if (NextScene == SceneManager.sceneCountInBuildSettings)
        {
            NextScene = 1;
        }

        SceneManager.LoadScene(NextScene);
        PlayerPrefs.SetInt("LastPlayedLevel", NextScene);
    }

    void AddCrash()
    {
        if (!_playerCrashed)
        {
            int crashes = PlayerPrefs.GetInt("Crashes");

            crashes++;
            PlayerPrefs.SetInt("Crashes", crashes);

            _playerCrashed = true;
        }
    }

}
