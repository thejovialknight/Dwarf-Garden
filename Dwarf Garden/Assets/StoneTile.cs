using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTile : MonoBehaviour, IActable
{
    DiggableTile diggable;

    void Awake() {
        diggable = GetComponent<DiggableTile>();
    }

    public bool Action(GameObject actor, PlayerController player) {
        if(diggable.Dig(actor)) {
            return true;
        }
        
        return false;
    }
}
