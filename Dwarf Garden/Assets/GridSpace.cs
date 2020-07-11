using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSpace
{
    public int x;
    public int y;
    public GameObject tile;
    public List<Entity> entities = new List<Entity>();

    public GridSpace(GameObject tile, params Entity[] entities)
    {
        this.tile = tile;
        this.entities = entities.ToList<Entity>();
    }

    public GameObject SetTile(GameObject tilePrefab)
    {
        GameObject newTile = GameObject.Instantiate(tilePrefab, tile.transform);
        GameObject.Destroy(tile);
        tile = newTile;
        return newTile;
    }

    public void AddEntity(Entity entity)
    {
        entities.Add(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        entities.Remove(entity);
    }
}
