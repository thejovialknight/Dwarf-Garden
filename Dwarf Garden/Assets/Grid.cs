using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    GridSpace[,] grid;

    public Grid(int width, int height)
    {
        grid = new GridSpace[width, height];
    }

    public int Width()
    {
        return grid.GetLength(0);
    }

    public int Height()
    {
        return grid.GetLength(1);
    }

    public GridSpace Space(int xPos, int yPos)
    {
        if (grid.GetLength(0) > xPos && grid.GetLength(1) > yPos)
        {
            return grid[xPos, yPos];
        }
        return null;
    }

    public GridSpace Space(Transform transform)
    {
        return Space((int)transform.position.x, (int)transform.position.y);
    }

    public GridSpace AddSpace(int x, int y, GridSpace space)
    {
        grid[x, y] = space;
        return space;
    }
}
