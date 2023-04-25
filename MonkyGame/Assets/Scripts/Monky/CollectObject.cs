using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public int peanutCount;
    
    private void Awake()
    {
        ResetCount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            peanutCount = peanutCount + 1;
            Destroy(other.gameObject);
        }
    }
    public void ResetCount()
    {
        peanutCount = 0;
    }
}
