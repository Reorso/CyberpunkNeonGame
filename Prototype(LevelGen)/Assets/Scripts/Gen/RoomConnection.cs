using UnityEngine;
using Delaunay.Geo;

public enum ConnectionType
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3,
}

public class RoomConnection
{
    public ConnectionType Direction
    {
        get;
        private set;
    }
    public Room Room
    {
        get;
        private set;
    }

    public LineSegment Line1;
    public LineSegment Line2;

    public RoomConnection(Room room, ConnectionType direction)
    {
        Room = room;
        Direction = direction;
    }
    public Vector2 GetDirectionVector()
    {
        switch(Direction){
            case ConnectionType.Up:
                return new Vector2(0,1);
            case ConnectionType.Down:
                return new Vector2(0, -1);
            case ConnectionType.Right:
                return new Vector2(1, 0);
            case ConnectionType.Left:
                return new Vector2(-1, 0);
            default:
                return Vector2.zero;
        }
    }
}
