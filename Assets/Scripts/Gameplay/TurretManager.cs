using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;

    private MapController mapController;
    private List<GameObject> allTurrets;
    private Dictionary<Direction, List<GameObject>> turrets;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
        allTurrets = new List<GameObject>();
        turrets = new Dictionary<Direction, List<GameObject>>();
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            turrets[direction] = new List<GameObject>();
        }

        // Placing the turrets
        for (int i = 0; i < mapController.mapSizeInTiles.x; i++)
        {
            turrets[Direction.down].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, -1), Quaternion.Euler(0, 0, 0)));
            turrets[Direction.up].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, mapController.mapSizeInTiles.y), Quaternion.Euler(0, 0, 180)));
        }
        for (int i = 0; i < mapController.mapSizeInTiles.y; i++)
        {
            turrets[Direction.left].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(-1, i), Quaternion.Euler(0, 0, -90)));
            turrets[Direction.right].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(mapController.mapSizeInTiles.x, i), Quaternion.Euler(0, 0, 90)));
        }

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            foreach (GameObject turret in turrets[direction])
            {
                allTurrets.Add(turret);
            }
        }
    }

    public void LaunchBullet(GameObject bulletPrefab)
    {
        GameObject turret = allTurrets[UnityEngine.Random.Range(0, turrets.Count)];
        GameObject bullet = Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = 50 * turret.transform.up;
    }

    public void LaunchBullet(GameObject bulletPrefab, int position, Direction wall)
    {
        GameObject turret = turrets[wall][position];
        GameObject bullet = Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = 50 * turret.transform.up;
    }
}
