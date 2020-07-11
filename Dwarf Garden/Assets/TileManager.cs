using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public MapGenerationSettings mapSettings;

    public Grid grid;
    public List<TypeTilePair> placeableTiles = new List<TypeTilePair>();

    public static TileManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetupMatch()
    {
        GetComponent<MapGenerator>().GenerateLevel();
    }

    public void PlaceTile(int x, int y, Tile tile)
    {
        grid.Space(x, y).SetTile(GetTilePrefab(tile));
    }

    public GameObject GetTilePrefab(Tile tile)
    {
        foreach(TypeTilePair pair in placeableTiles)
        {
            if(pair.tile == tile)
            {
                return pair.prefab;
            }
        }
        return null;
    }
}

public enum Tile
{
    Ground,
    Stone
}