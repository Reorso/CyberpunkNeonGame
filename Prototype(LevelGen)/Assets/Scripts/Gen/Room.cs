using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    //public List<Door> Doors
    //{
    //    get;
    //    set;
    //}
    GameObject enemy;
    public int ID
    {
        get;
        private set;
    }
    public bool IsMainRoom
    {
        get;
        private set;
    }
    public bool IsVisible
    {
        get;
        private set;
    }
    public bool IsLocked
    {
        get;
        private set;
    }
    public bool IsSleeping
    {
        get
        {
            return RigidBody2D.IsSleeping();
        }
    }
    public bool IsStartRoom
    {
        get;
        private set;
    }
    public bool IsEndRoom
    {
        get;
        private set;
    }

    public Vector3 Center
    {
        get
        {
            return transform.position;
        }
    }
    public Vector3 TopLeft
    {
        get
        {
            return new Vector3(transform.position.x - transform.localScale.x / 2f, transform.position.y + transform.localScale.y / 2f);
        }
    }
    public Vector3 BottomRight
    {
        get
        {
            return new Vector3(transform.position.x + transform.localScale.x / 2f, transform.position.y - transform.localScale.y / 2f);
        }
    }

    Color SecondaryColor = new Color(0.8f, 0.8f, 0.8f);
    Color MainColor = new Color(200f / 255f, 150f / 255f, 65 / 255f);
    Color DisabledColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);

    Color StartRoomColor = new Color(90 / 255f, 195 / 255f, 90 / 255f);
    Color EndRoomColor = new Color(195 / 255f, 85 / 255f, 165 / 255f);

    SpriteRenderer Background;
    Rigidbody2D RigidBody2D;

    public List<RoomConnection> Connections
    {
        get;
        private set;
    }

    public List<Door> Doors
    {
        get;
        private set;
    }
    public GameObject door
    {
        get;
        private set;
    }
    void Awake()
    {
        Background = GetComponent<SpriteRenderer>();
        RigidBody2D = GetComponent<Rigidbody2D>();

        Connections = new List<RoomConnection>();

        IsVisible = true;
    }

    public void Init(int id, Vector2 position, int width, int height)
    {
        ID = id;

        transform.position = position;
        transform.localScale = new Vector2(width, height);


    }

    public void SetMain()
    {
        IsMainRoom = true;
    }

    public void SetLocked(bool locked)
    {
        IsLocked = locked;
    }

    public void SetVisible(bool visible)
    {
        IsVisible = visible;
    }

    public void SetStartRoom()
    {
        IsStartRoom = true;
    }

    public void SetEndRoom()
    {
        IsEndRoom = true;
    }

    public void AddRoomConnection(RoomConnection connection)
    {
        if (!Connections.Contains(connection))
        {
            Connections.Add(connection);
        }
    }

    public void Snap()
    {
        int x = Mathf.CeilToInt(transform.position.x);
        int y = Mathf.FloorToInt(transform.position.y);

        transform.position = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        if (!IsLocked)
        {
            Snap();
        }
        
        if(this.enemy != null)
        {
            if (this.enemy.transform.childCount <= 0)
            {
                door.GetComponent<Door>().active = true;
                this.enemy = null;
            }
        }
    }

    void Update()
    {
        if (IsVisible)
        {
            if (IsMainRoom)
            {
                if (IsStartRoom)
                    Background.color = StartRoomColor;
                else if (IsEndRoom)
                    Background.color = EndRoomColor;
                else
                    Background.color = MainColor;
            }
            else
                Background.color = SecondaryColor;
        }
        else
        {
            Background.color = DisabledColor;
        }
    }

    public void GenerateLocalRoom(int width, int height, Vector2 centre)
    {
        GetComponent<Collider2D>().isTrigger = true;
        GameObject room = new GameObject("room" + ID);
        room.transform.position = transform.position;
        room.transform.rotation = Quaternion.identity;
        room.transform.parent = this.transform;
        LevelGenerator lv = room.AddComponent(typeof(LevelGenerator)) as LevelGenerator;
        lv.Generate(width, height, centre);
        GenerateDoors();
        IsLocked = true;
        GetComponent<SpriteRenderer>().enabled = false;
        enemy = lv.Enemy();
    }
    public void GenerateLocalRoom(int width, int height, Vector2 centre, bool start_end)
    {
        GetComponent<Collider2D>().isTrigger = true;
        GameObject room = new GameObject("room" + ID);
        room.transform.position = transform.position;
        room.transform.rotation = Quaternion.identity;
        room.transform.parent = this.transform;
        LevelGenerator lv = room.AddComponent(typeof(LevelGenerator)) as LevelGenerator;
        lv.Generate(width, height, centre,start_end);
        GenerateDoors();
        IsLocked = true;
        GetComponent<SpriteRenderer>().enabled = false;
        enemy = lv.Enemy();
    }

    void GenerateDoors()
    {
        door = Instantiate(Resources.Load("Door") as GameObject);
        door.transform.parent = this.transform;
        door.transform.localPosition = Vector3.zero;
    }
}
