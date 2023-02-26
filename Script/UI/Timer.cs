using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        string minutes = Mathf.Floor(GameManager.TimeLeft / 60).ToString("00");
        string seconds = (GameManager.TimeLeft % 60).ToString("00");
        text.text = minutes + ":" + seconds;
    }
}
