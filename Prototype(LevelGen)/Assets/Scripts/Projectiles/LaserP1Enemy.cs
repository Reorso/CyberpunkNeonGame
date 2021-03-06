﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserP1Enemy : MonoBehaviour {
    public float speed;
    public Vector2 initialpos;
    public float maxDist;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed * Time.deltaTime;
        initialpos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Vector2.Distance(initialpos, transform.position) >= maxDist)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Finish") && !collision.CompareTag("Door") && !collision.CompareTag("Room") && !collision.CompareTag("Door") && !collision.CompareTag("Bullet")) { 
            Destroy(this.gameObject);
        }
        print(collision.gameObject.name);
    }


}
