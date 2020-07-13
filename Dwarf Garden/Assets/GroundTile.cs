using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour, IActable
{
    MoveableTile moveable;

    void Awake() {
        moveable = GetComponent<MoveableTile>();
    }

    public bool Action(GameObject actor, PlayerController player) {
        if(moveable.Move(actor)) {
            return true;
        }
        
        return false;
    }
}
