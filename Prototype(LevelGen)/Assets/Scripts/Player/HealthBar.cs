using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public float offset = 0.3f;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.identity;
        Vector3 pos = transform.parent.position;
        pos.y -= offset;
        transform.position = pos;
	}
}
