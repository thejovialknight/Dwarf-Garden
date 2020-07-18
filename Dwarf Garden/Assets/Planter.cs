using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : ActionController
{
    // obviously replace with direct control of seed storage
    public SeedType seed = SeedType.Gem;

    public override void Awake() {
        base.Awake();
    }

    public override bool Action(GridSpace space) {
        Debug.Log("Planting, bitches!");
        GameObject obj;
        if(space.Action(ActionType.Plant, out obj)) {
            PlantableTile plantable = obj.GetComponent<PlantableTile>();
            if(plantable != null) {
                StartCoroutine(StartPlant(space, plantable));
                return true;
            }
        }

        return false;
    }

    IEnumerator StartPlant(GridSpace space, PlantableTile plantable) 
    {
        unit.isControllable = false;

        yield return new WaitForSeconds(0.5f);

        plantable.Plant(seed);
        Debug.Log("Planted!, bitches!");
        unit.isControllable = true;
    }
}
