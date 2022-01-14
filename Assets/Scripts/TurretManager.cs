using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;

    private MapController mapController;
    private List<GameObject> turrets;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
        turrets = new List<GameObject>();

        // quaternion moet nog aangepast
        // Placing the turrets
        for (int i = 0; i < mapController.mapSizeInTiles.x; i++)
        {
            turrets.Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, -1), Quaternion.Euler(0, 0, 90)));
            turrets.Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(i, mapController.mapSizeInTiles.y), Quaternion.Euler(0, 0, 90)));
        }
        for (int i = 0; i < mapController.mapSizeInTiles.y; i++)
        {
            turrets.Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(-1, i), Quaternion.Euler(0, 0, 90)));
            turrets.Add(Instantiate(turretPrefab, mapController.GridPositionToWorldPosition(mapController.mapSizeInTiles.x, i), Quaternion.Euler(0, 0, 90)));
        }
    }

    public void LaunchBullet(GameObject bulletPrefab)
    {
        GameObject turret = turrets[Random.Range(0, turrets.Count)];
        GameObject bullet = Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = 4 * turret.transform.up;
    }
}
