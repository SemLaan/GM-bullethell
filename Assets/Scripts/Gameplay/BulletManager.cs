using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private TurretManager turretManager;
    private MapController mapController;
    [SerializeField] private GameObject basicBulletPrefab;
    private List<IPattern> bulletPatterns;

    private float timer = 0f;

    private void Awake()
    {
        turretManager = FindObjectOfType<TurretManager>();
        mapController = FindObjectOfType<MapController>();
        bulletPatterns = new List<IPattern>();
        bulletPatterns.Add(new RowPattern());
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= 0.7)
        {
            timer -= 0.7f;
            bulletPatterns[0].CreateBulletPattern(6, basicBulletPrefab, turretManager, mapController);
        }
    }
}
