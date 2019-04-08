using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapActivator : MonoBehaviour {
    Color c;
	// Use this for initialization
	void Start () {
        c = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Map") > 0)
        {
            c.a = 1;
            this.gameObject.GetComponent<Image>().material.color = c;
        }
        else
        {
            c.a = 0;
            this.gameObject.GetComponent<Image>().material.color = c;
        }
	}
}
