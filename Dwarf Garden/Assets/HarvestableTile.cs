using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableTile : MonoBehaviour
{
    public List<Sprite> growthSprites = new List<Sprite>();
    public SpriteRenderer spriteRenderer;

    public int currentGrowth;
    public int maxGrowth;

    public void Grow() {
        currentGrowth++;
        if(currentGrowth > maxGrowth) {
            currentGrowth = maxGrowth;
        }
        spriteRenderer = growthSprites[currentGrowth];
    }

    public void Harvest() {

    }
}
