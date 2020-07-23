using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActableEntity : MonoBehaviour, IActable
{
    public List<ActableController> actables = new List<ActableController>();

    public bool Action(ActionType type) {
        foreach(ActableController actable in actables) {
            if(actable.action == type) {
                return actable.Action();
            }
        }

        return false;
    }
}
