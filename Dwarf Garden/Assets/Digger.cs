using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : ActionController
{
    public float power = 1f;

    public override void Awake() {
        base.Awake();
    }

    public override bool Action(GridSpace space) {
        GameObject obj;
        if(space.Action(ActionType.Dig, out obj)) {
            DiggableTile diggable = obj.GetComponent<DiggableTile>();
            if(diggable != null) {
                StartCoroutine(StartDig(space, diggable));
                return true;
            }
        }

        return false;
    }

    IEnumerator StartDig(GridSpace space, DiggableTile diggable) 
    {
        unit.isControllable = false;

        yield return new WaitForSeconds(0.5f);

        diggable.health -= power;

        if(diggable.health <= 0f) {
            diggable.Destroy();
            Mover mover = GetComponent<Mover>();
            if(mover != null) {
                mover.Action(space);
            }
        }
        else {
            unit.isControllable = true;
        }
    }
}
