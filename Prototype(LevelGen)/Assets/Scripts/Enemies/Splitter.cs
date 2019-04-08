using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {
    //public Transform[] path;

    public GameObject healthBar;
    public float health, maxhealth;
    Rigidbody2D rb;

    public GameObject childrens;

    float startTime = 0;
    public float waitFor = 2;
    bool timerStart = false;

    public Transform target;
    bool active = true, chasing = false, attacking = false;
    Vector2 direction;

    public float speed, minRadius, minPlayerRadius;
    int currStep = 0;
    
    public Quaternion desiredRot;
    public float rotSpeed;

 
    // Use this for initialization
    void Start ()
    {
        direction = new Vector3(1,1);
        rb = GetComponent<Rigidbody2D>();
        if(Random.value < 0.5)
        {
            direction *= -1;
        }
        health = maxhealth;

    }
	
	// Update is called once per frame
	void Update ()
    {
 
        if (active)
        {
            Follow();
        }
	}
    void Follow()
    {

        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, minPlayerRadius, LayerMask.GetMask("Sight"));
        if (!attacking) { 
            //if (players.Length > 0)
            //{
            //    Vector2 distance = players[0].transform.position - this.transform.position;
            //    chasing = true;
            //    rb.velocity = distance.normalized * speed;
            //    if(distance.magnitude < minRadius)
            //    {
            //        attacking = true;
            //    }
            //}
            //else
            //{

            rb.velocity = direction.normalized * speed;

            //}
        }
        else
        {
            GetComponent<Animator>().SetBool("attacking", true);
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
      

        switch (other.tag)
        {
            case "Bullet":
                Damage(1);
                break;
            case "TrojanBullet":
                Damage(1.5f);
                break;
            case "WormBullet":
                Damage(0.5f);
                break;
            case "BackdoorBullet":
                Damage(2);
                break;
            case "FisherBullet":
                Damage(1);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.GetContact(0).normal);
    }

    void Damage(float amount)
    {
        if (health <= 1)
        {
            if (maxhealth > 1) { 
                Instantiate(childrens, transform.position, Quaternion.identity, transform.parent.parent);
                Instantiate(childrens, transform.position + new Vector3(0.1f,0.1f,0), Quaternion.identity, transform.parent.parent);
            }
            Destroy(transform.gameObject);
        }
        else
        {
            healthBar.SetActive(true);
            health -= amount;
            Vector3 scale = healthBar.transform.localScale;
            scale.x *= (health / maxhealth);
            healthBar.transform.localScale = scale;
            minPlayerRadius = 100;
        }
    }
    void Bounce(Vector2 normal)
    {
        direction = Vector2.Reflect(direction, normal);
    }

}