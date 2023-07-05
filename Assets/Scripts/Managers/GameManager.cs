using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsCounter;
    [SerializeField] TextMeshProUGUI levelHeader;
    [SerializeField] int levelNumber;
    [SerializeField] public int StarsInLevel;
    [SerializeField] AudioClip starAudio;

    public int StarsAmount = 0;
    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        UpdateStarsCounter();

        LevelAnnounce();
    }

    void LevelAnnounce()
    {
        string s = levelNumber.ToString();
        levelHeader.text = "Level " + s;
               
    }

    public void PickedUpStar()
    {
        StarsAmount++;
        audioSource.PlayOneShot(starAudio);
        UpdateStarsCounter();
    }

    void UpdateStarsCounter()
    {
        string s = StarsInLevel.ToString();
        string str = StarsAmount.ToString();
        starsCounter.text = str + "/" + s;
    }
}
