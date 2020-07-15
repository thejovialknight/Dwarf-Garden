using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    Unit unit;
    Animator animator;

    public Vector3 targetPos;

    void Awake() {
        targetPos = transform.position;

        unit = GetComponent<Unit>();
        animator = GetComponent<Animator>();
    }

    public bool Move(GridSpace space) {
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
