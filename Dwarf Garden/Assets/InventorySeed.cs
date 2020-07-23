using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySeed : MonoBehaviour
{
    public SeedType type;
    public int amount;

    public InventorySeed(SeedType type, int amount) {
        this.type = type;
        this.amount = amount;
    }
}
