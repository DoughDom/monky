using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TimerUpdate timer;

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        timer.stopped = true;
    }
}
