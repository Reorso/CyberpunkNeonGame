using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door{

    Vector3 direction;
    Door destination;
    Vector3 position;
    Room parent;

    public Door(Room parent, int direction, Door destination)
    {
        this.parent = parent;
        switch(direction){
            case 0:
                this.direction = new Vector3(0,1,0);
                break;
            default:
                break;
        }
        this.destination = destination;
    }

    public void setDirection()
    {
        if(direction.x == 0)
        {
            position = direction * (int)((parent.TopLeft.y - parent.BottomRight.y) / 2);
        }
        else
        {
            position = direction * (int)((parent.BottomRight.x - parent.TopLeft.x) / 2);
        }
    }
}
