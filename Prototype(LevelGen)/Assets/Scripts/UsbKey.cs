using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbKey : MonoBehaviour
{

    private float horizontalSpeed;
    public float verticalSpeed;
    public float a;
    float startPosition;
    Vector3 tempPosition;

    void Start()
    {
        tempPosition = transform.position;
    }

    void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * a + tempPosition.y;
        transform.position = tempPosition;
    }
}
