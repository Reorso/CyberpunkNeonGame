using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    public float speed = 0f, c = 10;


    void Update()
    {
        speed = Input.GetAxis("Horizontal");
        if (speed != 0)
        {
            transform.Rotate(Vector3.up, speed * c * Time.deltaTime);
        }

    }
}
