using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Power") > 0.2)
        {
            this.gameObject.tag = "Undetectable";
        }
        else
        {
            this.gameObject.tag = "Player";
        }

	}
}
