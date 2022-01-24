using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseGraterPattern : IPattern
{
    public void CreateBulletPattern(int bullets, GameObject bulletPrefab, TurretManager turretManager, MapController mapController)
    {
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
        int wallSize = updown ? mapController.mapSizeInTiles.x : mapController.mapSizeInTiles.y;
        // Deciding if the even or uneven tiles will get the bullets
        int plusOne = Random.value > 0.5 ? 1 : 0;
        // Creating the bullets
        for (int i = 0; i < wallSize; i++)
        {
            if ((i + plusOne) % 2 == 0)
            {
                turretManager.LaunchBullet(bulletPrefab, i, wall);
            }
        }
    }
}
