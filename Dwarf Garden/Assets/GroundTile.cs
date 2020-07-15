using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour, IActable
{
    MoveableTile moveable;

    void Awake() {
        moveable = GetComponent<MoveableTile>();
    }

    public bool Action(ActionType type) {
        if(type == ActionType.Move && moveable == true) {
            return true;
        }

        return false;
    }
}
