using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeedTilePair
{
    public SeedType seed;
    public GameObject prefab;

    public SeedTilePair(SeedType seed, GameObject prefab)
    {
        this.seed = seed;
        this.prefab = prefab;
    }
}
