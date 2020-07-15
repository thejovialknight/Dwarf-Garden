using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInputHandler : MonoBehaviour
{
    Unit unit;

    void Awake() {
        unit = GetComponent<Unit>();
    }

    void Update() {
        if(Input.GetButtonDown("Up")) {
            unit.Action(0, 1);
        }

        if(Input.GetButtonDown("Right")) {
            unit.Action(1, 0);
        }

        if(Input.GetButtonDown("Down")) {
            unit.Action(0, -1);
        }

        if(Input.GetButtonDown("Left")) {
            unit.Action(-1, 0);
        }

        if(Input.GetButtonDown("Secondary")) {
            unit.Action(0, 0, true);
        }
    }
}
