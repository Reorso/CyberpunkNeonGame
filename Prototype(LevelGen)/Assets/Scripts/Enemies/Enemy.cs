﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //public Transform[] path;
    public float startTime = 0;
    public float waitFor = 2;
    bool timerStart = false;
    public Transform target;
    bool active = true, chasing = false;
    public float speed, minRadius, minPlayerRadius;
    int currStep = 0;
    Rigidbody2D rb;
    public float life = 5;
    public Quaternion desiredRot;
    public float rotSpeed;

    // Use this for initialization
    void Start () {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        //transform.up = path[currStep].position - transform.position;
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            Follow();
        }
	}
    void Follow()
    {

        Vector2 distance;
        distance =  target.position - this.transform.position;
        if(distance.magnitude < minPlayerRadius)
        {
            chasing = true;
            transform.up = distance;
            rb.velocity = transform.up * speed;
        }
        else
        {
            if (Time.time - startTime > new IntRange(2,5).Random)
            {
                //Do something
                rb.velocity = Vector3.zero;
                desiredRot = Quaternion.Euler(new Vector3(new IntRange(0, 2).Random, new IntRange(0, 2).Random, 0).normalized);
                transform.up = new Vector3(new IntRange(0,2).Random, new IntRange(0, 2).Random, 0).normalized;
                startTime = Time.time;
            }
        }
        //else 
        //{
        //    transform.up = path[currStep].position - transform.position;
        //    if (Vector2.Distance(transform.position, path[currStep].position) <= minRadius) { 
        //        currStep++;
        //        currStep = currStep % path.Length;
        //    }
        //    //rb.velocity = transform.up * speed;
        //    //print(currstep);
        //}

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if(life <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                life--;
            }
        }
    }

}