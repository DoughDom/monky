using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUpdate : MonoBehaviour
{
    private TextMeshProUGUI UIText;
    public float timePassed;
    public bool stopped;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        timePassed = 0f;
        stopped = false;
    }

    private void LateUpdate()
    {
        if(!stopped)
        {
            timePassed += Time.deltaTime;
        }
        int minutes = (int)timePassed / 60;
        int seconds = (int)timePassed % 60;
        int milliseconds = (int)(timePassed * 1000) % 1000;
        string sMin = minutes.ToString();
        string sSec = seconds.ToString();
        string sMill = milliseconds.ToString();
        
        if(seconds < 10)
        {
            sSec = "0" + seconds.ToString();
        }
        
        UIText.text = sMin + ":" + sSec + "." + sMill;
    }
}
