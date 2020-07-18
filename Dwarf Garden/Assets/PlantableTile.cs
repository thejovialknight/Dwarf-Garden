using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableTile : MonoBehaviour
{
    public void Plant(SeedType seed) {
        TileManager.Instance.PlaceSeed((int)transform.position.x, (int)transform.position.y, seed);
    }
}
