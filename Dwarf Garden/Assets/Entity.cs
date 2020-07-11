using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int x;
    public int y;

    void Awake()
    {
        UpdatePosition();
    }

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        x = (int)transform.position.x;
        y = (int)transform.position.y;
    }
}
