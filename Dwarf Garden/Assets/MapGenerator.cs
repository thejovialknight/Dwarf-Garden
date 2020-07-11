using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public void GenerateLevel()
    {
        TileManager tiles = TileManager.Instance;
        MapGenerationSettings settings = tiles.mapSettings;

        float[,] stoneMap = GenerateNoiseMap(settings.seedMultiplier, settings);
        float[,] moistureMap = GenerateNoiseMap(settings.moistureScale, settings);

        tiles.grid = new Grid(settings.width, settings.height);
        for(int x = 0; x < tiles.grid.Width(); x++)
        {
            for(int y = 0; y < tiles.grid.Height(); y++)
            {
                GridSpace space;
                if (stoneMap[x, y] <= settings.stoneChance)
                {
                    space = TileManager.Instance.PlaceTile(x, y, Tile.Stone);
                }
                else
                {
                    space = TileManager.Instance.PlaceTile(x, y, Tile.Ground);
                }
                space.SetMoisture(moistureMap[x, y]);
            }
        }
    }

    public float[,] GenerateNoiseMap(float multiplier, MapGenerationSettings settings)
    {
        float seed = Random.Range(-1000f, 1000f);
        float[,] noiseMap = new float[settings.width, settings.height];
        for (int x = 0; x < noiseMap.GetLength(0); x++)
        {
            for (int y = 0; y < noiseMap.GetLength(1); y++)
            {
                noiseMap[x, y] = Mathf.PerlinNoise(x + seed * multiplier, y + seed * multiplier);
            }
        }
        return noiseMap;
    }
}
