using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour {

    //public GameObject[] shifter;
    public Color[] shifterC;
    public Sprite[] shifterS;
    SpriteRenderer sr;
    Animator an;
    int current = 0;
    Vector3 tempPos;
    Quaternion tempRot;
    public KeyCode skill;
    bool alreadyPressed = true;
    // Use this for initialization
    void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        an = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetAxis("Swap") > 0.2)
        {
            if (!alreadyPressed)
            {
                ShapeShift();
                alreadyPressed = true;
            }
        }
        else
        {
            alreadyPressed = false;
        }

        if (Input.GetAxis("Power") > 0.2 )
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
        an.enabled = false;
        current++;
        //current %= shifterC.Length;
        //sr.color = shifterC[current];

        current %= shifterS.Length;
        print(current);
        sr.sprite = shifterS[current];
        if(current == 0)
        {
            an.enabled = true;
        }
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
