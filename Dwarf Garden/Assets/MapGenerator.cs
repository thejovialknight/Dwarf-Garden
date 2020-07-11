using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public void GenerateLevel()
    {
        TileManager tiles = TileManager.Instance;
        MapGenerationSettings settings = tiles.mapSettings;

        float seed = Random.Range(-1000f, 1000f);

        float[,] noiseMap = new float[tiles.mapWidth, tiles.mapHeight];
        for (int x = 0; x <= noiseMap.GetLength(0); x++)
        {
            for(int y = 0; y <= noiseMap.GetLength(1); y++)
            {
                noiseMap[x, y] = Mathf.PerlinNoise(seed, seed);
            }
        }

        tiles.grid = new Grid(tiles.mapWidth, tiles.mapHeight);
        for(int x = 0; x <= tiles.grid.Width(); x++)
        {
            for(int y = 0; y <= tiles.grid.Height(); y++)
            {
                if (noiseMap[x, y] <= settings.stoneChance)
                {
                    TileManager.Instance.PlaceTile(x, y, Tile.Ground);
                }
                else
                {
                    TileManager.Instance.PlaceTile(x, y, Tile.Stone);
                }
            }
        }
    }
}
