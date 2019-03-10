using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public Transform arm;
    public float speed = 5;
    public Vector2 direction, rot;
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
    }

    // Update is called once per frame
    void FixedUpdate() {

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction != Vector2.zero) {

            rb.velocity = direction * speed * Time.fixedDeltaTime;
            this.an.SetBool("Moving",true);

        }
        else
        {
            this.an.SetBool("Moving", false);
        }
        

        mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       
        rot = new Vector2(
            mpos.x - arm.position.x, 
            mpos.y - arm.position.y
            );
        arm.up = rot;

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
        sr.flipX = state;
        if(facingRight != state)
        {
            arm.localPosition = new Vector3(-arm.localPosition.x, arm.localPosition.y);
            facingRight = state;
        }

    }
}
