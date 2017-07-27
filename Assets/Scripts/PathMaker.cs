using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour {

    public GameObject[] tiles;

    public List<Vector3> createdTiles;

    public int tileNumber;
    public int tileSize;

    public float chanceUp;
    public float chanceRight;
    public float chanceDown;

    public float waitTime;


	// Use this for initialization
	void Start () {
        StartCoroutine(GenerateLevel());
	}

    IEnumerator GenerateLevel()
    {
        int tileNumber = Random.Range(20, 150);
        for(int i = 0; i< tileNumber; i++)
        {   
            float dir = Random.Range(0f, 1f); // 0-1  will determine which direction the next tile will go.
            int tile = Random.Range(0, tiles.Length);

            CreateTiles(tile);

            CallMoveTiles(dir);

            yield return new WaitForSeconds(waitTime);
        }
        yield return 0;
    }

    void CallMoveTiles(float ranDir)
    {
        if (ranDir < chanceUp)
        {
            MoveTiles(0);
        }
        else if (ranDir < chanceRight)
        {
            MoveTiles(1);
        }
        else if (ranDir < chanceDown)
        {
            MoveTiles(2);
        }
        else
        {
            MoveTiles(3);
        }
    }

    void MoveTiles(int dir)// direction generator will move
    {
        switch (dir)
        {
            case 0:

                transform.position = new Vector3(transform.position.x, 0, transform.position.z + tileSize);

                break;

            case 1:

                transform.position = new Vector3(transform.position.x + tileSize, 0, transform.position.z);

                break;

            case 2:

                transform.position = new Vector3(transform.position.x, 0, transform.position.z - tileSize);

                break;

            case 3:

                transform.position = new Vector3(transform.position.x - tileSize, 0, transform.position.z);

                break;
        }
    }

    void CreateTiles(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;

            createdTiles.Add(tileObject.transform.position);
        }
        else
        {
            tileNumber++;
        }
    }
}

