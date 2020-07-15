using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public float power = 1f;

    Unit unit;
    Animator animator;

    void Awake() {
        unit = GetComponent<Unit>();
        animator = GetComponent<Animator>();
    }

    public void Plant(PlantableTile plantable, ) {
        StartCoroutine(AnimatePlant(plantable));
    }

    IEnumerator AnimatePlant(PlantableTile plantable) 
    {
        unit.isControllable = false;

        yield return new WaitForSeconds(0.5f);

        unit.isControllable = true;
    }
}
