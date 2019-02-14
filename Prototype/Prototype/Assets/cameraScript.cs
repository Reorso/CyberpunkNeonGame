using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public Transform target;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        pos.x = target.position.x;
        pos.y = target.position.y;
        print(pos);
        transform.position = pos;
	}
}
