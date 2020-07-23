using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggableTile : ActableController
{
    public float maxHealth = 3f;
    public float health = 3f;

    void Awake() {
        action = ActionType.Dig;
    }

    public override bool Action() {
        return true;
    }

    public void Destroy() {
        TileManager.Instance.PlaceTile((int)transform.position.x, (int)transform.position.y, Tile.Ground);
    }
}
