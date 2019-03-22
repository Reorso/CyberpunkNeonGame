using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCodeBullet : MonoBehaviour {

    public float speed;
    public Vector2 initialpos;
    public float maxDist;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        initialpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(initialpos, transform.position) >= maxDist)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            print("hit");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            GetComponentInParent<RedCode>().AddClone(transform.position);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        GetComponentInParent<RedCode>().AddClone(transform.position);
    //    }
    //}
}
