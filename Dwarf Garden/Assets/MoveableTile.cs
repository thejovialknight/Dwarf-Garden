using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTile : ActableController
{
    void Awake() {
        action = ActionType.Move;
    }

    public override bool Action() {
        return true;
    }
}
