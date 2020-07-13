using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggableTile : MonoBehaviour
{
    public bool isDiggable = true;

    public float maxHealth = 3f;
    public float health = 3f;

    GameObject actor;

    public bool Dig(GameObject actor) {
        this.actor = actor;
        if(isDiggable) {
            Digger digger = actor.GetComponent<Digger>();
            digger.Dig(this);

            return true;
        }

        return false;
    }

    public void Destroy() {
        TileManager.Instance.PlaceTile((int)transform.position.x, (int)transform.position.y, Tile.Ground);
    }
}
