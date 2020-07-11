using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
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

    public GridSpace PlaceTile(int x, int y, Tile tile)
    {
        GridSpace space = grid.Space(x, y);
        GameObject prefab = GetTilePrefab(tile);
        if (space != null)
        {
            space.SetTile(prefab);
        }
        else
        {
            space = grid.AddSpace(x, y, new GridSpace(x, y, prefab));
        }
        return space;
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