using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour, IActable
{
    MoveableTile moveable;
    PlantableTile plantable;

    void Awake() {
        moveable = GetComponent<MoveableTile>();
        plantable = GetComponent<PlantableTile>();
    }

    public bool Action(ActionType type) {
        if(type == ActionType.Move && moveable == true) {
            return true;
        }
        if(type == ActionType.Plant && plantable == true) {
            return true;
        }

        return false;
    }
}
