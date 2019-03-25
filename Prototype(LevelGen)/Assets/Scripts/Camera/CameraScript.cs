using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target;
    Vector3 mousepos,shootingDir, direction;
    public float smoothTime = 0.3f, offset = 5;
    private Vector3 desiredPos,velocity = Vector3.zero;

	
	// Update is called once per frame
	void FixedUpdate () {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        shootingDir.x = Input.GetAxisRaw("ShootingHorizontal");
        shootingDir.y = Input.GetAxisRaw("ShootingVertical");
        shootingDir = (shootingDir + direction).normalized * offset;
        if(target != null)
            desiredPos = target.position + shootingDir / 2;
        desiredPos.z = -10;

        //mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //mousepos = mousepos.normalized * offset;
        //desiredPos = target.position + mousepos / 2;
        //desiredPos.z = -10;


        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);


	}
}
