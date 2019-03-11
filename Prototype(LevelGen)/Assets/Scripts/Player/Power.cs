using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {
    public KeyCode power;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(power))
        {
            this.gameObject.tag = "Undetectable";
        }
        else
        {
            this.gameObject.tag = "Player";
        }

	}
}
