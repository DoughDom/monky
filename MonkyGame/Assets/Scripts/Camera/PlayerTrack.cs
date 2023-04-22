using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrack : MonoBehaviour
{
    public Transform player;
    public Transform floor;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = player.position.y;
        transform.position = pos;
    }
}
