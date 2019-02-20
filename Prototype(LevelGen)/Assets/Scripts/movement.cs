using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public float speed = 5;
    public Vector2 direction, rot;
    Vector3 mpos;
    Rigidbody2D rb;
    Transform tr;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        rb.velocity = direction * speed * Time.deltaTime;

        mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = new Vector2(
            mpos.x - tr.position.x, 
            mpos.y - tr.position.y
            );
        tr.up = rot;
    }
}
