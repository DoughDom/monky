using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private Object thisObject;
    
    private void Awake()
    {
        thisObject = GetComponent<Object>();
        ResetCount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(thisObject.ID, PlayerPrefs.GetInt(thisObject.ID) + 1);
            Destroy(gameObject);
        }
    }
    public void ResetCount()
    {
        PlayerPrefs.SetInt(thisObject.ID, 0);
    }
}
