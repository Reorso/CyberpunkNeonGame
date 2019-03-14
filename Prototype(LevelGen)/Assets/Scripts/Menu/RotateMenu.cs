using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    public float speed = 1, c = 0, smooth = 3, quantity, clamp;
    Quaternion rot, desiredRot;
    private void Start()
    {
        desiredRot = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

    }

    void Update()
    {
        c += Time.deltaTime;
        rot = transform.localRotation;
        desiredRot = Quaternion.Slerp(rot, desiredRot, quantity * c / smooth);
        transform.rotation = Quaternion.Slerp(rot, desiredRot, speed * c / smooth);
        if (c >= smooth || Vector3.Distance(desiredRot.eulerAngles, rot.eulerAngles) < clamp)
        {
            desiredRot = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360),Random.Range(0, 360)));
            c = 0;
        }

    }
}
