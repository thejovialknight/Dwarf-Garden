using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public float power = 1f;

    Unit unit;
    Animator animator;

    void Awake() {
        unit = GetComponent<Unit>();
        animator = GetComponent<Animator>();
    }

    public void Dig(DiggableTile diggable) {
        StartCoroutine(AnimateDig(diggable));
    }

    IEnumerator AnimateDig(DiggableTile diggable) 
    {
        unit.isControllable = false;

        yield return new WaitForSeconds(0.5f);

        diggable.health -= power;

        if(diggable.health <= 0f) {
            diggable.Destroy();
            Mover mover = GetComponent<Mover>();
            if(mover != null) {
                mover.Move(diggable.transform.position);
            }
        }
        else {
            unit.isControllable = true;
        }
    }
}
