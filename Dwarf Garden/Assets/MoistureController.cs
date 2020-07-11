using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoistureController : MonoBehaviour
{
    public GridSpace space;
    public float moisture;
    public SpriteRenderer dryRenderer;
    public SpriteRenderer moistRenderer;

    void Start()
    {
        Entity entity = GetComponent<Entity>();
        space = TileManager.Instance.grid.Space(entity.x, entity.y);
    }

    void Update()
    {
        moisture = space.moisture;
        moistRenderer.color = new Color(1, 1, 1, moisture);
    }
}
