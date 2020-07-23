using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStorage : MonoBehaviour
{
    List<InventorySeed> seeds = new List<InventorySeed>();

    public int Amount(SeedType type) {
        foreach(InventorySeed seed in seeds) {
            if(seed.type == type) {
                return seed.amount;
            }
        }

        return 0;
    }  

    public void Add(SeedType type, int amount) {
        foreach(InventorySeed seed in seeds) {
            if(seed.type == type) {
                seed.amount += amount;
                return;
            }
        }

        seeds.Add(new InventorySeed(type, amount));
    }       

    public void Remove(SeedType type, int amount) {
        for (int i = seeds.Count - 1; i >= 0; i--) {
            InventorySeed seed = seeds[i];
            if(seed.type == type) {
                seed.amount -= amount;
                if(seed.amount <= 0) {
                    seeds.RemoveAt(i);
                }
                return;
            }
        }

        Debug.Log("Can't remove that which is not there the seedling...");
    }     
}

public enum SeedType {
    Gem,
    Mushroom,
    Snail
}