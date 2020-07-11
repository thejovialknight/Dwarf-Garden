using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Generation Settings", menuName = "ScriptableObjects/Map Generation Settings")]
public class MapGenerationSettings : ScriptableObject
{
    public int width = 25;
    public int height = 25;
    public float seedMultiplier = 1f;
    public float stoneChance = 0.9f;
    public float moistureScale = 1f;
}
