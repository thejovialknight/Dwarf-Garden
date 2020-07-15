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

    public void Action(int x, int y) {
        int xPos = (int)transform.position.x + x;
        int yPos = (int)transform.position.y + y;

        if(!isControllable || !isActive || TileManager.Instance.Space(xPos, yPos) == null) {
            return;
        }

        GridSpace space = TileManager.Instance.Space(xPos, yPos);

        if(x != 0 || y != 0) {
            Mover mover = GetComponent<Mover>();
            Digger digger = GetComponent<Digger>();
            if(mover != null && mover.Move(space)) {
                isActionInProgress = true;
            }
            else if (digger != null && digger.Dig(space)){
                isActionInProgress = true;
            }
        }

        Input.ResetInputAxes();
    }
}


// TileManager.Instance.Space(xPos, yPos).Action(gameObject, controller, true)