using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour {

    public GameObject enterDoors;
    public GameObject[] exitDoors;
    public GameObject enemies;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //print(enemies.transform.childCount + gameObject.name);
        if (enemies.transform.childCount <= 0)
        {
            //print("deactivating" + gameObject.name);
            Deactivate();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enterDoors.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enterDoors.SetActive(true);
        }
    }


    void Deactivate()
    {
        if(enterDoors != null)
            enterDoors.SetActive(false);

        foreach(GameObject door in exitDoors)
            door.SetActive(false);
    }
}
