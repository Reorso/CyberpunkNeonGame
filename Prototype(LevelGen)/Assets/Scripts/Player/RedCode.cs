using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCode : MonoBehaviour
{
    private List<GameObject> clones;
    public GameObject bullet, clone;
    public float coolDown;
    private float time;

	// Use this for initialization
	void Start ()
    {
        time = 0;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(time < coolDown)
        {
            time += Time.deltaTime;
        }
		else if(Input.GetAxis("Power") > 0)
        {
            ShootSpecial();
            time = 0;
        }
	}

    void ShootSpecial()
    {
        GameObject temp = Instantiate(bullet, transform.parent);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localRotation = Quaternion.identity;

    }

    public void AddClone(Vector3 pos)
    {
        clones.Add(Instantiate(clone, pos, Quaternion.identity));
    }
}

