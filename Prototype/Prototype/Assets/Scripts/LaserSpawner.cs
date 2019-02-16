using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {
    public GameObject laserP;
    GameObject temp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
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
