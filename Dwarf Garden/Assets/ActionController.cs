using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public Unit unit;
    public Animator animator;

    public virtual void Awake() {
        unit = GetComponent<Unit>();
    }

    public virtual bool Action(GridSpace space) {
        return false;
    }
}