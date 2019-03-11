using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour {

    //public GameObject[] shifter;
    public Color[] shifterC;
    SpriteRenderer sr;
    int current = 0;
    Vector3 tempPos;
    Quaternion tempRot;
    public KeyCode skill;

	// Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShapeShift();
        }
        if (Input.GetKeyDown(skill))
        {
            SkillActivate(current);
        }
	}
    void ShapeShift()
    {
        //shifter[current].SetActive(false);
        //tempPos = shifter[current].transform.position;
        //tempRot = shifter[current].transform.rotation;
        //current++;
        //current %= shifter.Length;
        //shifter[current].SetActive(true);
        //shifter[current].transform.position = tempPos;
        //shifter[current].transform.rotation = tempRot;

        current++;
        current %= shifterC.Length;
        sr.color = shifterC[current];
    }
    void SkillActivate(int form)
    {
        switch (form)
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                print("error, from not existent");
                break;
        }
    }
}
