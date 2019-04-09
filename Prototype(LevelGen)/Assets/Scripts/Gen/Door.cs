using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{

    Vector3 direction;
    List<Door> destinations;
    Vector3 position;
    bool collision = false, delay = false, teleport = false;
    public bool active = false;
    GameObject player;
    int rand;

    private void Start()
    {
        delay = true;
        position = transform.position;
    }

    public void AddDestination(Door newDest)
    {
        if(destinations != null)
        {
            if (!destinations.Contains(newDest))
                destinations.Add(newDest);
        }
        else
        {
            destinations = new List<Door>
            {
                newDest
            };
        }

    }

    private void Update()
    {
        if (active)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            if (collision)
            {
                if (Input.GetAxis("Door") > 0.1 && delay)
                {
                    player.GetComponent<Collider2D>().enabled = false;
                    player.GetComponent<PlayerMovement>().Deactivate();
                    teleport = true;
                    rand = (int)Random.Range(0, destinations.Count);
                    delay = false;
                }
            }
            if (teleport)
            {
                if (Mathf.Abs((player.transform.position - destinations[rand].position).magnitude) <= 1)
                {
                    teleport = false;
                    player.GetComponent<Collider2D>().enabled = true;
                    delay = true;
                    player.GetComponent<PlayerMovement>().Deactivate();
                }
                else
                {
                    Teleport(destinations[rand].position);
                }
            }
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

    public void Teleport(Vector3 dest)
    {
        player.transform.position = Vector3.Lerp(player.transform.position, dest, Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.collision = true;
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.collision = false;
        }
    }
}

