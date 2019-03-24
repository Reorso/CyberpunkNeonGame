using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : MonoBehaviour
{
    public GameObject trojanBullet;
    public float coolDown = 7;
    float time;
    float hiddenTime;
    bool disguised = false;
    Color c;


    void Start ()
    {
        time = coolDown;
        hiddenTime = 0;
        c = GetComponentInParent<SpriteRenderer>().material.color;
    }
	
	void Update ()
    {
        if (!disguised)
        { 
		    if (time < coolDown)
            {
                time += Time.deltaTime;
            }
            else if (Input.GetAxis("Power") > 0)
            {
                Disguise();
                hiddenTime += Time.deltaTime;
                time = 0;
            }
        }
        else
        { 
            if (hiddenTime <= 5)
            {
                hiddenTime += Time.deltaTime;
            }
            else 
            {
                transform.parent.gameObject.layer = 8;
                c.a = 1;
                GetComponentInParent<SpriteRenderer>().material.color = c;
                disguised = false;

            }
        }
    }

    void Disguise()
    {
        hiddenTime = 0;
        disguised = true;
        transform.parent.gameObject.layer = 0;
        c.a = 0.30f;
        GetComponentInParent<SpriteRenderer>().material.color = c;
    }

   // IEnumerator DisguiseC()
   // {
   //     transform.gameObject.tag = "Undetectable";
   //     yield return new WaitForSeconds(5f);
   //     transform.gameObject.tag = "Player";
   // }

}
