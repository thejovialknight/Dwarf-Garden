using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableTile : ActableController
{
    public List<Sprite> growthSprites = new List<Sprite>();
    public SpriteRenderer spriteRenderer;

    public int currentGrowth;
    public int maxGrowth;

    public bool isFirstTurn = true;

    void OnEnable() {
        MatchManager.onTurnEnd += Grow;
    }

    void OnDisable() {
        MatchManager.onTurnEnd -= Grow;
    }

    void Awake() {
        action = ActionType.Harvest;
    }

    public override bool Action() {
        return true;
    }

    public void Grow() {
        if(isFirstTurn) {
            isFirstTurn = false;
        }
        else {
            currentGrowth++;
            if(currentGrowth > maxGrowth) {
                currentGrowth = maxGrowth;
            }
        }
        spriteRenderer.sprite = growthSprites[currentGrowth];
    }

    public void Harvest() {

    }
}
