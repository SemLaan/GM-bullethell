using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private int pixelsPerTile;
    private Vector2Int mapSizeInPixels;
    [HideInInspector] public Vector2Int mapSizeInTiles;

    private void Awake()
    {
        mapSizeInPixels = Vector2Int.RoundToInt(GetComponent<SpriteRenderer>().bounds.size);
        mapSizeInTiles = mapSizeInPixels / pixelsPerTile;
    }

    public Vector2 GridPositionToWorldPosition(Vector2Int gridPosition)
    {
        Vector2 worldPosition = (gridPosition * pixelsPerTile) - (mapSizeInPixels / 2);
        // Making sure the position returned is in the middle of the tile
        worldPosition += new Vector2(pixelsPerTile, pixelsPerTile) / 2;
        // Making sure the position is relative to the grid position
        worldPosition += (Vector2) transform.position;
        return worldPosition;
    }

    public Vector2 GridPositionToWorldPosition(int x, int y)
    {
        return GridPositionToWorldPosition(new Vector2Int(x, y));
    }

    /// <summary>
    /// Checks if the given grid position is out of bounds and returns it back into bounds if it is.
    /// </summary>
    /// <param name="gridPosition"></param>
    /// <returns></returns>
    public Vector2Int ReturnToGridBounds(Vector2Int gridPosition)
    {
        if (gridPosition.x < 0)
            gridPosition.x = 0;
        if (gridPosition.x >= mapSizeInTiles.x)
            gridPosition.x = mapSizeInTiles.x - 1;
        if (gridPosition.y < 0)
            gridPosition.y = 0;
        if (gridPosition.y >= mapSizeInTiles.y)
            gridPosition.y = mapSizeInTiles.y - 1;
        return gridPosition;
    }
}
