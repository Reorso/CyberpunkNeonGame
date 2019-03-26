using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    public RedCode origin;
    public Transform main;

    bool cd = false;
    public float startTime = 0;
    public float distance;
    private Vector2 randomposition;

    int health;
    public int maxhealth = 2;

    public GameObject healthBar;
    public Transform arm;

    public float speed = 5;
    public Vector2 direction, rot, shootingDir;
    private bool facingRight;

    //Vector3 mpos;
    Rigidbody2D rb;
    Transform tr;
    Animator an;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        health = maxhealth;
        randomposition = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (cd)
        {
            if (startTime - Time.time <= -2) {
                cd = false;
                startTime = 0;
            }
        }
        if(main != null) { 
            direction = main.position - transform.position;
            direction += randomposition;
        }
        shootingDir.x = Input.GetAxis("ShootingHorizontal");
        shootingDir.y = Input.GetAxis("ShootingVertical");

        if (direction != Vector2.zero) {

            rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;
            an.SetBool("Moving",true);
            if(shootingDir == Vector2.zero) { 
                an.SetFloat("Horizontal", direction.x);
                an.SetFloat("Vertical", direction.y);
            }
            else
            {
                an.SetFloat("Horizontal", shootingDir.x);
                an.SetFloat("Vertical", shootingDir.y);
            }
        }
        else
        {
            an.SetBool("Moving", false);
        }
        

        //mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       
        //rot = new Vector2(
        //  mpos.x - arm.position.x, 
        //  mpos.y - arm.position.y
        // );
        if(shootingDir != Vector2.zero)
        {
            arm.up = shootingDir;
        }
        else
        {
            arm.up = direction;
        }


        if (arm.localRotation.eulerAngles.z - 180 < 0) {
            Flip(true);
        }
        else
        {
            Flip(false);
        }

    }
    void Flip(bool state)
    {
        //sr.flipX = state;
        if(facingRight != state)
        {
            arm.localPosition = new Vector3(-arm.localPosition.x, arm.localPosition.y);
            facingRight = state;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {

            if (health <= 1)
            {
                Loose();
            }
            else if(!cd)
            {
                healthBar.SetActive(true);
                health--;
                print(health);
                Vector3 scale = healthBar.transform.localScale;
                scale.x *= (health / maxhealth);
                healthBar.transform.localScale = scale;
                cd = true;
                startTime = Time.time;
            }
        }
    }
    void Loose()
    {
        origin.RemoveClone(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
