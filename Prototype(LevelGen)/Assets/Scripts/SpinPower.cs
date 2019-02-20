using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPower : MonoBehaviour {
    public float rotSpeed;
    Transform tr;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
                tr.Rotate(Vector3.forward, rotSpeed, Space.Self);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.localRotation = Quaternion.identity;
        }
    }
}
