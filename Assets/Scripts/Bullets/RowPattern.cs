using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowPattern : IPattern
{
    public void CreateBulletPattern(int bullets, GameObject bulletPrefab, TurretManager turretManager, MapController mapController)
    {
        Direction wall = (Direction)Random.Range(0, 3);
        int startOfRow;
        if (wall == Direction.up || wall == Direction.down) // if wall is up or down
        {
            int wallLength = mapController.mapSizeInTiles.x;
            startOfRow = Random.Range(0, wallLength - bullets);
        } else //if wall is left or right
        {
            int wallLength = mapController.mapSizeInTiles.y;
            startOfRow = Random.Range(0, wallLength - bullets);
        }
        for (int i = startOfRow; i < startOfRow + bullets; i++)
        {
            turretManager.LaunchBullet(bulletPrefab, i, wall);
        }
    }
}
