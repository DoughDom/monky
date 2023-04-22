using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCam : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        pos.y = player.position.y;
        transform.position = pos;
    }
}
