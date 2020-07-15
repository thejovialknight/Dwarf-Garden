using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool isActive = false;
    public int actionLimit = 3;
    public int actionsTaken = 0;
    public bool isControllable = true;
    bool isActionInProgress = false;

    public PlayerController controller;

    void Update() {
        if(isControllable && isActionInProgress) {
            isActionInProgress = false;
            actionsTaken++;
            if(actionsTaken >= actionLimit) {
                Deactivate();
                controller.ActivateNextUnit();
            }   
        }

        
    }

    public bool Activate() {
        if(actionsTaken >= actionLimit) {
            return false;
        }

        isActive = true;
        return true;
    }

    public void Deactivate() {
        actionsTaken = 0;
        isActive = false;
    }

    public void Action(int x, int y, bool isSecondary) {
        int xPos = (int)transform.position.x + x;
        int yPos = (int)transform.position.y + y;

        if(!isControllable || !isActive) {
            return;
        }

        if(TileManager.Instance.Space(xPos, yPos).Action(gameObject, controller, true)) {
            isActionInProgress = true;
        }

        Input.ResetInputAxes();
    }

    public void Action(int x, int y) {
        Action(x, y, false);
    }
}
