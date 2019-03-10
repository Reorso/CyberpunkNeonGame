using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {
    public GameObject laserP;
    GameObject temp;
    float timeToFire = 0;
    public float fireRate = 2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(1) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }


	}

    void Shoot()
    {
        temp = Instantiate(laserP);
        temp.transform.position = transform.position;
        temp.transform.rotation = transform.rotation;
    }
}
