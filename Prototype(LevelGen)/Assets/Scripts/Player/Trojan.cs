using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : MonoBehaviour
{
    public GameObject trojanBullet;
    public float coolDown = 7;
    float time;
    float hiddenTime;

	void Start ()
    {
        time = 0;
        hiddenTime = 0;
	}
	
	void Update ()
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

    void Disguise()
    {
        transform.gameObject.tag = "Undetectable";
        if (hiddenTime >= 5)
        {
            transform.gameObject.tag = "Player";
        }
        hiddenTime = 0;
    }

   // IEnumerator DisguiseC()
   // {
   //     transform.gameObject.tag = "Undetectable";
   //     yield return new WaitForSeconds(5f);
   //     transform.gameObject.tag = "Player";
   // }

}
