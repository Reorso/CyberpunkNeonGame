using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserP : MonoBehaviour {
    public float speed;
    public Vector2 initialpos;
    public float maxDist;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        initialpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(initialpos, transform.position) >= maxDist)
        {
            print("my battery is running low... it's getting darker");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");
        Destroy(this.gameObject);
    }
}
