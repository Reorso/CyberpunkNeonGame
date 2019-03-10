using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target;
    Vector3 mousepos;
    public float smoothTime = 0.3f, offset = 5;
    private Vector3 desiredPos,velocity = Vector3.zero;

	
	// Update is called once per frame
	void FixedUpdate () {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousepos = mousepos.normalized* offset;
        desiredPos = target.position + mousepos / 2;
        desiredPos.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos,ref velocity, smoothTime);


	}
}
