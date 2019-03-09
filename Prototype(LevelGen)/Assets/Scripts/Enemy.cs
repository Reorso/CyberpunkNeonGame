using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform[] path;
    bool active = true;
    public float speed,minRadius;
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

        //transform.up = path[currStep].position - transform.position;
        //rb.velocity = transform.up * speed;
        //if (Vector2.Distance(transform.position, path[currStep].position)<=minRadius)
        //{
        //    currStep++;
        //    currStep = currStep % path.Length;
        //    rb.velocity = transform.up * speed;
        //    print(currstep);
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