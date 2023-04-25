using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TimerUpdate timer;
    [SerializeField] private GameObject Player;
    private int totalPeanuts;
    [SerializeField] private bool peanutCountOn;

    void Awake()
    {
        totalPeanuts = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (totalPeanuts == Player.GetComponent<CollectObject>().peanutCount && peanutCountOn)
        {
            timer.stopped = true;
        }
        else if (totalPeanuts == Player.GetComponent<CollectObject>().peanutCount)
        {
            timer.stopped = true;
        }
    }
}
