using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableTile : ActableController
{
    void Awake() {
        action = ActionType.Plant;
    }

    public override bool Action() {
        return true;
    }

    public void Plant(SeedType seed) {
        TileManager.Instance.PlaceSeed((int)transform.position.x, (int)transform.position.y, seed);
    }
}
