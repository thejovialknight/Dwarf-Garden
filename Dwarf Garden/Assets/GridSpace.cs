using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridSpace
{
    public int x;
    public int y;
    public float moisture = 0.5f;
    public GameObject tile;
    public List<Entity> entities = new List<Entity>();

    public GridSpace(int x, int y, GameObject tile, params Entity[] entities)
    {
        this.x = x;
        this.y = y;
        SetTile(tile);
        this.entities = entities.ToList<Entity>();
    }

    public void SetMoisture(float moisture)
    {
        this.moisture = moisture;
    }

    public GameObject SetTile(GameObject tilePrefab)
    {
        GameObject.Destroy(tile);
        tile = GameObject.Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
        return tile;
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
