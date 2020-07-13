using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTile : MonoBehaviour
{
    bool isPassable = true;

    public bool Move(GameObject actor) {
        if(isPassable) {
            Mover mover = actor.GetComponent<Mover>();
            mover.Move(transform.position);
            return true;
        }

        return false;
    }
}
