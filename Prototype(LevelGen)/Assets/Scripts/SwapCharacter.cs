using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour {

    public GameObject[] shifter;
    int current = 0;
    Vector3 tempPos;
    Quaternion tempRot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShapeShift();
        }
	}
    void ShapeShift()
    {
        shifter[current].SetActive(false);
        tempPos = shifter[current].transform.position;
        tempRot = shifter[current].transform.rotation;
        current++;
        current %= shifter.Length;
        shifter[current].SetActive(true);
        shifter[current].transform.position = tempPos;
        shifter[current].transform.rotation = tempRot;
    }
}
