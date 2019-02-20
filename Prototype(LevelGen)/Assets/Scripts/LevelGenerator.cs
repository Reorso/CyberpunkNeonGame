using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Floor stuff
    public GameObject[] tiles; //Modify this from unity to set how many floor tiles u want
    public GameObject wall;
    public List<Vector3> createdTiles;
    public int tileAmount;
    public int tileSize;
    public float waitTime;

    //Changing this will make the levels lean to different directions (if chanceRight has more probability than the others the level will be more likely to be going to the right and viceversa)
    //For equal chances set like so: 
    public float chanceUp;      //0.25
    public float chanceRight;   //0.5
    public float chanceDown;    //0.75

   //Generic stuff
    public int seed;
    public bool enableSeed;

    //Walls stuff
    public float minY = 9999999;
    public float maxY = 0;
    public float minX = 9999999;
    public float maxX = 0;
    public float xWalls;
    public float yWalls;
    public float extraWallsX; //Change the amount of extra walls in each axis (x in this case) if that makes ant sense (recommended = 5 for both)
    public float extraWallsY; //Change the amount of extra walls in each axis (y in this case) if that makes ant sense ("")



    void Start ()
    {
        StartCoroutine(GenerateLevel());
        if (enableSeed == true)
        {
            Random.InitState(seed);
        }
        else
        {
            //nothing bruh
        }
	}

    IEnumerator GenerateLevel()
    {
        for(int a=0; a<tileAmount; a++)
        {
            float direction = Random.Range(0f, 1f);
            int tile = Random.Range(0, tiles.Length);

            CreateTile(tile);
            ProbMoveGen(direction);

            yield return new WaitForSeconds(waitTime);

            if (a == tileAmount - 1)
            {
                Finish();
            }
        }

        yield return 0;
	}
    
    void ProbMoveGen(float RandomDirection)
    {
        if (RandomDirection < chanceUp)
        {
            MoveGen(0);
        }
        else if (RandomDirection < chanceRight)
        {
            MoveGen(1);
        }
        else if (RandomDirection < chanceDown)
        {
            MoveGen(2);
        }
        else
        {
            MoveGen(3);
        }
    }

    void MoveGen(int direction)
    {
        switch (direction)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
                break;

            case 1:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
                break;

            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
                break;

            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if(!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;
            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);
        }
        else
        {
            tileAmount++;
        }
    }

    void Finish()
    {
        CreateWallValues();
        CreateWalls();
    }

    void CreateWallValues()
    {
        for (int a=0; a<createdTiles.Count; a++)
        {
            if (createdTiles[a].y < minY)
            {
                minY = createdTiles[a].y;
            }

            if (createdTiles[a].y > maxY)
            {
                maxY = createdTiles[a].y;
            }

            if (createdTiles[a].x < minX)
            {
                minX = createdTiles[a].x;
            }

            if (createdTiles[a].x > maxX)
            {
                maxX = createdTiles[a].x;
            }

            xWalls = ((maxX - minX) / tileSize) + extraWallsX;
            yWalls = ((maxY - minY) / tileSize) + extraWallsY;
        }
    }

    void CreateWalls()
    {
        for(int x=0; x < xWalls; x++)
        {
            for(int y = 0; y < yWalls; y++)
            {
                if (!createdTiles.Contains(new Vector3((minX - (extraWallsX * tileSize)/2 ) + (x * tileSize), (minY - (extraWallsY * tileSize) /2) + (y * tileSize))))
                {
                    Instantiate(wall, new Vector3((minX - (extraWallsX * tileSize) /2) + (x * tileSize), (minY - (extraWallsY * tileSize)/2 ) + (y * tileSize)), transform.rotation);
                }
            }
            
        }
    }
}
