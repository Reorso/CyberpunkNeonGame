using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public Transform arm;
    public float speed = 5;
    public Vector2 direction, rot;
    Vector3 mpos;
    Rigidbody2D rb;
    Transform tr;
    Animator an;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction != Vector2.zero) {

            rb.velocity = direction * speed * Time.deltaTime;
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

    }
}
