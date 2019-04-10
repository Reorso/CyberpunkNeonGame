using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {

        public GameObject laserP;
        GameObject temp;
        float timeToFire = 0;
        public float fireRate = 2;
        private Vector2 shootingDir;

        // Use this for initialization
        void Start () {
		
	    }
	
	// Update is called once per frame
	void FixedUpdate () {

        shootingDir.x = Input.GetAxis("ShootingHorizontal");
        shootingDir.y = Input.GetAxis("ShootingVertical");

        if(Input.GetAxis("Shoot") > 0.1f)
        {
            if (shootingDir != Vector2.zero && Time.time > timeToFire)
            {

                timeToFire = Time.time + 1 / fireRate;
                Shoot();

            }
        }
    }

    void Shoot()
    {

        temp = Instantiate(laserP);
        temp.transform.position = transform.position;
        temp.transform.up = shootingDir;

    }
}
