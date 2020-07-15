using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableTile : MonoBehaviour
{
    bool isPlantable = true;

    public bool Plant(GameObject actor) {
        if(isPlantable) {
            Planter planter = actor.GetComponent<Planter>();
            if(planter.CanPlant())
            planter.Plant(transform.position);
            return true;
        }

        return false;
    }
}
