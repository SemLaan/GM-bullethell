using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPattern
{
    /// <summary>
    /// Can tell the turrets to create some pattern of bullets.
    /// </summary>
    /// <param name="bullets">The amount of bullets that are going to be part of the pattern</param>
    /// <param name="bulletPrefab">Prefab for the bullet type that the pattern is going to launch</param>
    /// <param name="turretManager">The only turret manager that exists in the scene</param>
    /// <param name="mapController">The only map controller that exists in the scene</param>
    public void CreateBulletPattern(int bullets, GameObject bulletPrefab, TurretManager turretManager, MapController mapController);
}
