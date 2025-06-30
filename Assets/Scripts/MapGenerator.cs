using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] TileObject grassPrefab;
    [SerializeField] TileObject forestPrefab;
    [SerializeField] TileObject waterPrefab;
    [SerializeField] Transform tileParent;
    
    const int WIDTH = 15;
    const int HEIGHT = 9;

    const int WATER_RATE = 10;
    const int FOREST_RATE = 30;

    public List<TileObject> Generate()
    {
        List<TileObject> tileObjects = new List<TileObject>();

        Vector2 offset = new Vector2(-WIDTH / 2, -HEIGHT / 2);
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                Vector2 pos = new Vector2(x, y) + offset;
                int rate = Random.Range(0, 100);
                TileObject tileObject = null;
                if (rate < WATER_RATE)
                {
                    tileObject = Instantiate(waterPrefab, pos, Quaternion.identity, tileParent);
                }
                else if (rate < WATER_RATE + FOREST_RATE)
                {
                    tileObject = Instantiate(forestPrefab, pos, Quaternion.identity, tileParent);
                }
                else
                {
                    tileObject = Instantiate(grassPrefab, pos, Quaternion.identity, tileParent);
                }
                tileObject.positionInt = new Vector2Int((int)pos.x, (int)pos.y);
                tileObjects.Add(tileObject);
            }
        }
        return tileObjects;
    }

}
