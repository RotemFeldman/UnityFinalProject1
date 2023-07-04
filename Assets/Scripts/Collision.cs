using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Build.Content;
using System.Threading;

public class Collision : MonoBehaviour
{
    public UIManager UI;
    
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                LoadNextLevel();
                break;
            case "Coin":
                UI.PickedUpCoin();
                Destroy(collision.gameObject);
                break;
            case "Start":
                break; 
            default:
                ReloadLevel();
                break;
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
            NextScene = 0;
        }
        SceneManager.LoadScene(NextScene);
    }

    
}
