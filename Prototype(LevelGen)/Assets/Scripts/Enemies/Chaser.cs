using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {
    //public Transform[] path;
    public GameObject healthBar;
    public float startTime = 0;
    public float waitFor = 2;
    bool timerStart = false;
    public Transform target;
    bool active = true, chasing = false;
    public float speed, minRadius, minPlayerRadius;
    int currStep = 0;
    Rigidbody2D rb;
    public float health = 5, maxhealth = 5;
    public Quaternion desiredRot;
    public float rotSpeed;

    // Use this for initialization
    void Start ()
    {

        //target = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.up = path[currStep].position - transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        //target = GameObject.FindGameObjectWithTag("Player").transform;



        if (active)
        {
            Follow();
        }
	}
    void Follow()
    {
        //if (distance.magnitude < minPlayerRadius && target != null)

        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, minPlayerRadius, LayerMask.GetMask("Sight"));
        if (players.Length > 0)
        {
            Vector2 distance = players[(int)Random.Range(0,players.Length)].transform.position - this.transform.position;
            chasing = true;
            transform.up = distance;
            rb.velocity = transform.up * speed;
        }
        else
        {
            if (startTime > Random.Range(2,5))
            {
                //Do something
                rb.velocity = Vector3.zero;
                desiredRot = Quaternion.Euler(0, 0, Random.Range(1,360));
                //transform.up = new Vector3(new IntRange(0,2).Random, new IntRange(0, 2).Random, 0).normalized;
                startTime = 0;
            }
            else
            {
                startTime += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, Time.deltaTime);
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

    void Damage(float amount)
    {
        if (health <= 1)
        {
            Destroy(this.gameObject);
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

}