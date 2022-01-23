using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;

    private MapController mapController;
    private List<TurretController> allTurrets;
    private Dictionary<Direction, List<TurretController>> turrets;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
    }

    private void Start()
    {
        allTurrets = new List<TurretController>();
        turrets = new Dictionary<Direction, List<TurretController>>();
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            turrets[direction] = new List<TurretController>();
        }

        // Placing the turrets
        for (int i = 0; i < mapController.mapSizeInTiles.x; i++)
        {
            turrets[Direction.down].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, -1), Quaternion.Euler(0, 0, 0)).GetComponent<TurretController>());
            turrets[Direction.up].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, mapController.mapSizeInTiles.y), Quaternion.Euler(0, 0, 180)).GetComponent<TurretController>());
        }
        for (int i = 0; i < mapController.mapSizeInTiles.y; i++)
        {
            turrets[Direction.left].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(-1, i), Quaternion.Euler(0, 0, -90)).GetComponent<TurretController>());
            turrets[Direction.right].Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(mapController.mapSizeInTiles.x, i), Quaternion.Euler(0, 0, 90)).GetComponent<TurretController>());
        }

        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            foreach (TurretController turret in turrets[direction])
            {
                allTurrets.Add(turret);
            }
        }
    }

    public void LaunchBullet(GameObject bulletPrefab)
    {
        TurretController turret = allTurrets[UnityEngine.Random.Range(0, allTurrets.Count)];
        turret.QueueBullet(bulletPrefab, 1f);
    }

    public void LaunchBullet(GameObject bulletPrefab, int position, Direction wall)
    {
        TurretController turret = turrets[wall][position];
        turret.QueueBullet(bulletPrefab, 1f);
    }
}
