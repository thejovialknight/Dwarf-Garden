using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggableTile : MonoBehaviour
{
    public bool isDiggable = true;

    public float maxHealth = 3f;
    public float health = 3f;

    GameObject actor;

    public void Destroy() {
        TileManager.Instance.PlaceTile((int)transform.position.x, (int)transform.position.y, Tile.Ground);
    }
}
