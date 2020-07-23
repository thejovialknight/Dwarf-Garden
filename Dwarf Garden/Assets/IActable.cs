using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActable
{
    //bool Action(GameObject actor, PlayerController player);
    bool Action(ActionType type);
}