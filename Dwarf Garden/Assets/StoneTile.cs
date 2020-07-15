using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTile : MonoBehaviour, IActable
{
    DiggableTile diggable;

    void Awake() {
        diggable = GetComponent<DiggableTile>();
    }

    public bool Action(ActionType type) {
        if(type == ActionType.Dig && diggable == true) {
            return true;
        }

        return false;
    }
}
