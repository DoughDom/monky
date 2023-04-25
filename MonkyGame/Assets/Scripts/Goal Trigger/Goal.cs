using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TimerUpdate timer;
    [SerializeField] private GameObject Player;
    private int totalPeanuts;
    public bool peanutCountOn;

    void Awake()
    {
        totalPeanuts = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (peanutCountOn)
        {
            if (totalPeanuts == Player.GetComponent<CollectObject>().peanutCount)
            {
                timer.stopped = true;
            }
        }
        else
        {
            timer.stopped = true;
        }
    }
}
