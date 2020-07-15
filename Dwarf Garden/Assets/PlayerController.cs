using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isActive;
    public int activeUnit;
    public List<Unit> units = new List<Unit>();

    public SeedStorage seeds;

    void Awake() {
        seeds = GetComponent<SeedStorage>();
    }

    public void StartTurn() {
        activeUnit = -1;
        isActive = true;
        ActivateNextUnit();
    }

    public void EndTurn() {
        isActive = false;
    }

    public void ActivateNextUnit() {
        if(activeUnit != -1 && ActiveUnit() != null) {
            ActiveUnit().Deactivate();
        }

        activeUnit++;

        if(activeUnit >= units.Count) {
            MatchManager.Instance.AdvanceTurn();
            return;
        }

        while(ActiveUnit().Activate() == false) {
            activeUnit++;
        }
    }

    public Unit ActiveUnit() {
        return units[activeUnit];
    }
}
