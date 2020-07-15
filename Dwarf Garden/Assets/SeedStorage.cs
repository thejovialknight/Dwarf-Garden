using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedStorage : MonoBehaviour
{
    Dictionary<SeedType, int> seeds = new Dictionary<SeedType>();

    public int Amount(SeedType type) {
        if(seeds.ContainsKey(type)) {
            return seeds[type];
        }
        return 0;
    }  

    public void Add(SeedType type, int amount) {
        if(seeds.ContainsKey(type) {
            seeds[type] += amount;
        }
        else {
            seeds.Add(type, amount);
        }
    }       
}

public enum SeedType {
    Gem,
    Mushroom,
    Snail
}