using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backdoor : MonoBehaviour
{
    public float distance = 5f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetAxis("Power") > 0)
        {
            Blink();
        }
	}

    void Blink()
    {
        //RaycastHit hit;
        Vector3 destination = transform.position + transform.forward * distance;
        
        if (Physics.Raycast(destination, -Vector3.up)) //out hit))
        {
            //destination = hit.point;
            transform.position = destination;
        }
    }
}
