using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;
    private Vector3 centre;
    int[,] grid;
    GameObject temp;

	public ColorToPrefab[] colorMappings;

    // Use this for initialization
    //void Start () {
    //	GenerateLevel();
    //}

    public void Generate(int width, int height, Vector2 centre)
    {
        grid = new int[width, height];
        map = Resources.Load<Texture2D>("room" + width + "x" + height + "_" + Random.Range(0, 4));
        this.centre = new Vector3(centre.x - width /2 + 0.5f, centre.y - height /2 + 0.5f, 0);
        GenerateGrid();
        GenerateLevel();
    }

    void GenerateGrid ()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GeneratePixel(x, y);
			}
		}
	}

	void GeneratePixel (int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
		{
            grid[x, y] = 0; 
			return;
		}
        else
        {
            if (pixelColor.Equals(Color.black))
            {

                    grid[x,y] = 1;

            }
            else
            {
                grid[x, y] = 2;
                if (pixelColor.Equals(Color.blue))
                {

                }
                if (pixelColor.Equals(Color.red))
                {
                    grid[x, y] = 3;
                }
                if (pixelColor.Equals(Color.green))
                {
                    grid[x, y] = 4;
                }
            }

            //Vector2 position = new Vector2(x, y) + centre;
            //GameObject temp = new GameObject(x + "  " + y);
            //temp.transform.position = position;
            //temp.transform.rotation = Quaternion.identity;
            //temp.transform.parent = transform;
        }
    }

    void GenerateLevel()
    {
        temp = new GameObject("Enemies");
        temp.transform.parent = transform;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                switch (grid[x, y])
                {
                    case 0:
                        InstantiateTile("Void", x, y, transform);
                        break;
                    case 1:
                        if (y == map.height - 1 || y != 0) { 
                            if(grid[x, y - 1] > 1)
                                InstantiateTile("Wall", x, y, transform);
                            else
                                InstantiateTile("Void", x, y, transform);
                        }
                        else
                            InstantiateTile("Void", x, y, transform);
                        break;
                    case 2:
                        InstantiateTile("Floor", x, y, transform);
                        break;
                    case 3:
                        InstantiateTile("Floor", x, y, transform);
                        InstantiateTile("Enemy", x, y, temp.transform);
                        break;
                    case 4:
                        InstantiateTile("Floor", x, y, transform);
                        InstantiateTile("Splitter4", x, y, temp.transform);
                        break;
                    default:
                        InstantiateTile("Void", x, y, transform);
                        break;
                }
            }
        }
    }
    void InstantiateTile(string name, int x, int y, Transform parent)
    {
        Instantiate(Resources.Load<GameObject>(name), new Vector3(x, y, -3) + centre, Quaternion.identity, parent);
    }
}
