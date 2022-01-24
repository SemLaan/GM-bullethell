using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowWithHolePattern : IPattern
{
    public void CreateBulletPattern(int bullets, GameObject bulletPrefab, TurretManager turretManager, MapController mapController)
    {
        if (bullets % 2 == 0)
            bullets++;
        // Randomizing which wall the pattern should be created on
        Direction wall;
        bool updown = Random.value > (mapController.mapSizeInTiles.y / ((float)mapController.mapSizeInTiles.x + mapController.mapSizeInTiles.y));
        if (updown)
        {
            wall = Random.value > 0.5 ? Direction.up : Direction.down;
        }
        else
        {
            wall = Random.value > 0.5 ? Direction.left : Direction.right;
        }
        int startOfRow;
        if (wall == Direction.up || wall == Direction.down) // if wall is up or down
        {
            int wallLength = mapController.mapSizeInTiles.x;
            startOfRow = Random.Range(0, wallLength - bullets + 1);
        }
        else //if wall is left or right
        {
            int wallLength = mapController.mapSizeInTiles.y;
            startOfRow = Random.Range(0, wallLength - bullets + 1);
        }
        for (int i = startOfRow; i < startOfRow + bullets; i++)
        {
            if (i != Mathf.Floor(bullets / 2) + startOfRow)
            {
                turretManager.LaunchBullet(bulletPrefab, i, wall);
            }
        }
    }
}
