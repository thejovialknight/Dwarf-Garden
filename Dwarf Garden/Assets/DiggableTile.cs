using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggableTile : MonoBehaviour
{
    public float maxHealth = 3f;
    public float health = 3f;

    public void Destroy() {
        TileManager.Instance.PlaceTile((int)transform.position.x, (int)transform.position.y, Tile.Ground);
    }
}
