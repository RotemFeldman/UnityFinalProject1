using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsCounter;
    [SerializeField] TextMeshProUGUI levelHeader;
    [SerializeField] int levelNumber;
    [SerializeField] public int coinsInLevel;

    public int coinsAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinsCounter();

        LevelAnnounce();
    }

    void LevelAnnounce()
    {
        string s = levelNumber.ToString();
        levelHeader.text = "Level " + s;
               
    }

    public void PickedUpCoin()
    {
        coinsAmount++;

        UpdateCoinsCounter();
    }

    void UpdateCoinsCounter()
    {
        string s = coinsInLevel.ToString();
        string str = coinsAmount.ToString();
        coinsCounter.text = str + "/" + s;
    }
}
