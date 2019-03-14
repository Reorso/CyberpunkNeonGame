using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    public float speed = 0f, c = 5;


    void Update()
    {
        speed = Input.GetAxis("Horizontal");
        speed = 1;
        if (speed != 0)
        {
            transform.Rotate(Vector3.up, speed * c * Time.deltaTime);
        }

    }

    public void SliderChange(float newValue)
    {
        c = newValue;

    }
}
