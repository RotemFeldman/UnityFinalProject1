using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public TextMeshProUGUI t;
    Color col;

    void Start()
    {
        col = t.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (col.a > 0)
        {
            col.a -= Time.deltaTime;
            t.color = col;
        }
    }
}
