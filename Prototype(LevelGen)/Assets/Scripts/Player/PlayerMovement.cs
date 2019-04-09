using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject healthbarPlayer;
    public GameObject loosePanel;
    bool cd = false, blocked = false;
    public float startTime = 0;
    float health = 6, maxhealth = 6;
    public GameObject healthBar;
    public Transform arm;
    public float speed = 5;
    public Vector2 direction, rot, shootingDir;
    private bool facingRight;
    Vector3 mpos;
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
        healthbarPlayer = GameObject.Find("Healthbar");
        //loosePanel = GameObject.FindGameObjectsWithTag("loosePanel")[0];
        //loosePanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate() {
        sr.flipX = false;
        if (cd)
        {
            if (startTime - Time.time <= -2) {
                cd = false;
                startTime = 0;
            }
        }

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        shootingDir.x = Input.GetAxis("ShootingHorizontal");
        shootingDir.y = Input.GetAxis("ShootingVertical");


        if (shootingDir != Vector2.zero)
        {
            arm.up = shootingDir;
        }
        else
        {
            arm.up = direction;
        }


        if (arm.localRotation.eulerAngles.z - 180 < 0)
        {
            Flip(true);
        }
        else
        {
            Flip(false);
        }


        if (direction != Vector2.zero && !blocked) 
        {

            rb.velocity = direction.normalized * speed * Time.fixedDeltaTime; 
            an.SetBool("Moving", true);
            if (shootingDir == Vector2.zero)
            {
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
            if (arm.localRotation.eulerAngles.z - 180 < 0)
            {
                sr.flipX = true;
            }
            an.SetBool("Moving", false);
        }
        //mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       
        //rot = new Vector2(
        //  mpos.x - arm.position.x, 
        //  mpos.y - arm.position.y
        // );


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
            Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Damage();
        }
    }

    void Damage()
    {
        if (health <= 1)
        {
            Loose();
        }
        else if (!cd)
        {
            health--;

            //healthBar.SetActive(true);
            //print(health);
            //Vector3 scale = healthBar.transform.localScale;
            //scale.x *= (health / maxhealth);
            //healthBar.transform.localScale = scale;

            print(health);
            Vector3 scale = healthbarPlayer.transform.localScale;
            scale.x *= (health / maxhealth);
            print(health / maxhealth + "" + health + "" + maxhealth);
            healthbarPlayer.transform.localScale = scale;

            cd = true;
            startTime = Time.time;
        }
    }

    void Loose()
    {
        Destroy(this.gameObject);
        loosePanel.SetActive(true);
    }

    public void Deactivate()
    {
        blocked = !blocked;
    }
}
