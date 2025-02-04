﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int debugX;
    public int debugY;
    public GridSpace debugSpace;

    public MapGenerationSettings mapSettings;

    public Grid grid;
    public List<TypeTilePair> placeableTiles = new List<TypeTilePair>();
    public List<SeedTilePair> plantableSeeds = new List<SeedTilePair>(); 

    public static TileManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() {
        debugSpace = Space(debugX, debugY);
    }

    public void SetupMatch()
    {
        GetComponent<MapGenerator>().GenerateLevel();
    }

    public GridSpace Space(int x, int y) {
        return grid.Space(x, y);
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

    public GridSpace PlaceSeed(int x, int y, SeedType seed)
    {
        GridSpace space = grid.Space(x, y);
        GameObject prefab = GetSeedPrefab(seed);
        if (space != null)
        {
            space.SetTile(prefab);
        }
        else
        {
            space = grid.AddSpace(x, y, new GridSpace(x, y, prefab));
        }
        Debug.Log(space.tile);
        return space;
    }

    public GameObject GetSeedPrefab(SeedType seed)
    {
        foreach(SeedTilePair pair in plantableSeeds)
        {
            if(pair.seed == seed)
            {
                return pair.prefab;
            }
        }
        return null;
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