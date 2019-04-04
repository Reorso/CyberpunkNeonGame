﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{

    Vector3 direction;
    List<Door> destinations;
    Vector3 position;
    bool activate = false;
    Transform player;

    private void Start()
    {
        position = transform.position;
    }

    public void AddDestination(Door newDest)
    {
        if(destinations != null) {
            if (!destinations.Contains(newDest))
                destinations.Add(newDest);
        }
        else
        {
            destinations = new List<Door>();
            destinations.Add(newDest);
        }

    }

    private void Update()
    {
        if (activate)
        {
            if (Input.GetAxis("Door") > 0.1)
            {
                Teleport();
            }
        }
    }

    public void Teleport()
    {
        player.position = destinations[(int)Random.Range(0, destinations.Count)].position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activate = true;
            player = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activate = false;
            player = null;
        }
    }
}

