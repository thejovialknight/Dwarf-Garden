using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Generation Settings", menuName = "ScriptableObjects/Map Generation Settings")]
public class MapGenerationSettings : ScriptableObject
{
    public float stoneChance = 0.5f;
}
