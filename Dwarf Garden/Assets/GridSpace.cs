using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class GridSpace
{
    public int x;
    public int y;
    public float moisture = 0.5f;
    public GameObject tile;
    public GameObject entity;

    public GridSpace(int x, int y, GameObject tile, GameObject entity)
    {
        this.x = x;
        this.y = y;
        SetTile(tile);
        this.entity = entity;
    }

    public GridSpace(int x, int y, GameObject tile)
    {
        this.x = x;
        this.y = y;
        SetTile(tile);
        this.entity = null;
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

    public void AssignEntity(GameObject entity) {
        this.entity = entity;
    }

    public bool Action(GameObject actor, PlayerController player) {
        bool isSuccessful = false;
        IActable actable;
        if(entity != null) {
            actable = entity.GetComponent<IActable>();
            if(actable != null && actable.Action(actor, player)) {
                return true;
            }
        }

        actable = tile.GetComponent<IActable>();
        if(actable != null && actable.Action(actor, player)) {
            return true;
        }

        return isSuccessful;
    }
}
