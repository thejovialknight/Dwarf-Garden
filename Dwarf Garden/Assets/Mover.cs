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

    public void Move(Vector3 target) {
        targetPos = target;
        StartCoroutine(AnimateMovement());
    }

    IEnumerator AnimateMovement() 
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
