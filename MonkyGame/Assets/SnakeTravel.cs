/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTravel : MonoBehaviour
{
    public float speed = 50f;
    public bool extended;
    public bool attached;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        attached = false;
        target = Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Transform.position == Monkey.Transform.position)
        {
            extended = false;
        }

        if (extended)
            rend.enabled = true;
            if (!attached)
                if(Input.GetMouseButton(0))
                {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = Transform.position.z;
                }
                else
                {
                    target = Monkey.Transform.position;
                }
                
                Transform.position = Vector3.MoveTowards(Transform.position, target, speed * Time.deltaTime);
        else
        {
            rend.enabled = false;
        }
    }
}
*/