using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShape : MonoBehaviour {

    public int stacks = 18, slices = 18;
    public float theta, phi;
    int[,] grid;
    public float radius = 1;
    public GameObject prefab;
    GameObject g;

    // Use this for initialization
    void Start () {
        g = new GameObject("jhonny");
        grid = new int[stacks,slices];
        for (int t = 0; t < stacks; t ++)
        {
            theta = (t / stacks) * Mathf.PI;
            for (int p = 0; p < slices; p++)
            {
                phi = (p / slices) * Mathf.PI;
                grid[t,p] = 1;
                SpawnSphere(t,p);
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnSphere(int t, int p)
    {
        float x, y, z;
        x = Mathf.Sin(t) * Mathf.Cos(p);
        y = Mathf.Sin(t) * Mathf.Sin(p);
        z = Mathf.Cos(t);
        //Mathf.Sin(t)
        Vector3 pos = new Vector3(x, y, z) * radius;
        print(pos);
        GameObject temp = Instantiate(prefab, pos, Quaternion.identity);
        temp.transform.parent = g.transform;
        //((x - x0)^2 + (y - y0)^2 + (z - z0)^2) * r^2 = 0
    }
}
