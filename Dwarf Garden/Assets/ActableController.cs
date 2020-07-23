using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActableController : MonoBehaviour
{
    public ActionType action;

    public virtual bool Action() {
        return false;
    }
}
