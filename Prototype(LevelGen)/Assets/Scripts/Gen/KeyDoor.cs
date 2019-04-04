using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {
    int keycount = 0;
    int collectiblesTaken = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keycount++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("KeyDoor"))
        {
            if(keycount > 0)
            {
                keycount--;
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("Door"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Collectible"))
        {
            collectiblesTaken++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("BossDoor"))
        {
            if (collectiblesTaken >= 5)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
