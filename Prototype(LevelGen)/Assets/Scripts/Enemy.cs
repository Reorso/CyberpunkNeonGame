using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform[] path;
    public Transform target;
    bool active = true, chasing = false;
    public float speed,minRadius, minPlayerRadius;
    int currStep = 0;
    Rigidbody2D rb;
    public float life = 5;

    // Use this for initialization
    void Start () {

        transform.up = path[currStep].position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

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
        }
        else 
        {
            transform.up = path[currStep].position - transform.position;
            if (Vector2.Distance(transform.position, path[currStep].position) <= minRadius) { 
                currStep++;
                currStep = currStep % path.Length;
            }
            //rb.velocity = transform.up * speed;
            //print(currstep);
        }
        rb.velocity = transform.up * speed;
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