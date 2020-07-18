using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : ActionController
{
    public float speed;

    public Vector3 targetPos;

    public override void Awake() {
        base.Awake();

        targetPos = transform.position;
    }

    public override bool Action(GridSpace space) {
        GameObject obj;
        if(space.Action(ActionType.Move, out obj)) {
            targetPos = space.Position();
            StartCoroutine(StartMovement());
            return true;
        }

        return false;
    }

    IEnumerator StartMovement() 
    {
        unit.isControllable = false;

        while(transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        unit.isControllable = true; 
    }
}
