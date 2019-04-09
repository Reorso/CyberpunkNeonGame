using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCode : MonoBehaviour
{
    private List<GameObject> clones;
    public GameObject bullet, clone;
    public float coolDown;
    private float time;
    bool hold = true;

	// Use this for initialization
	void Start ()
    {
        clones = new List<GameObject>();
        time = 0;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(time < coolDown)
        {
            time += Time.deltaTime;
        }
		else if(Input.GetAxis("Power") > 0.1)
        {
            hold = true;

            time = 0;
        }
        if(Input.GetAxis("Power") < 0.1 && hold)
        {
            hold = false;
            ShootSpecial();
        }
	}

    void ShootSpecial()
    {
        GameObject temp = Instantiate(bullet, transform.parent);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localRotation = this.transform.localRotation;
        temp.GetComponent<RedCodeBullet>().parent = this;
    }

    public void AddClone(Vector3 pos)
    {
        GameObject temp = Instantiate(clone, pos, Quaternion.identity);
        clones.Add(temp);
        temp.GetComponentInChildren<CloneMovement>().origin = this;
        temp.GetComponentInChildren<CloneMovement>().main = transform.parent;
    }

    public void RemoveClone(GameObject t)
    {
        clones.Remove(t);
    }
}

