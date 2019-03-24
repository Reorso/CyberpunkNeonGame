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
        time = 0;
        hiddenTime = 0;
        c = GetComponent<SpriteRenderer>().material.color;
    }
	
	void Update ()
    {
		if (time < coolDown)
        {
            time += Time.deltaTime;
        }
        else if (Input.GetAxis("Power") > 0 && !disguised)
        {
            Disguise();
            hiddenTime += Time.deltaTime;
            time = 0;
        }

        if (hiddenTime <= 5 && disguised)
        {
            hiddenTime += Time.deltaTime;
        }
        else 
        {
            transform.gameObject.tag = "Player";
            c.a = 255;
            disguised = false;

        }
    }

    void Disguise()
    {
        hiddenTime = 0;
        disguised = true;
        transform.gameObject.tag = "Undetectable";
        c.a = 150;
        GetComponent<SpriteRenderer>().material.color = c;
    }

   // IEnumerator DisguiseC()
   // {
   //     transform.gameObject.tag = "Undetectable";
   //     yield return new WaitForSeconds(5f);
   //     transform.gameObject.tag = "Player";
   // }

}
