using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TypeTilePair
{
    public Tile tile;
    public GameObject prefab;

    public TypeTilePair(Tile tile, GameObject prefab)
    {
        this.tile = tile;
        this.prefab = prefab;
    }
}
