using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private TurretManager turretManager;
    private MapController mapController;
    [SerializeField] private GameObject basicBulletPrefab;
    private List<IPattern> bulletPatterns;

    private float timeSinceStart = 0f;
    private float patternTimer = 0f;
    private float bulletTimer = 0f;

    private void Awake()
    {
        turretManager = FindObjectOfType<TurretManager>();
        mapController = FindObjectOfType<MapController>();
        bulletPatterns = new List<IPattern>();
        bulletPatterns.Add(new RowPattern());
    }

    private void FixedUpdate()
    {
        // Getting the current difficulty and updating all the timers
        float difficulty = CurrentDifficulty();
        timeSinceStart += Time.fixedDeltaTime;
        patternTimer += Time.fixedDeltaTime;
        bulletTimer += Time.fixedDeltaTime;
        // Checking if an individual bullet should be launched
        if (bulletTimer >= 1f / difficulty)
        {
            bulletTimer -= 1f / difficulty;
            turretManager.LaunchBullet(basicBulletPrefab);
        }
        // Checking if a pattern should be launched
        if (patternTimer >= 2f / difficulty)
        {
            patternTimer -= 2f / difficulty;
            bulletPatterns[0].CreateBulletPattern(6, basicBulletPrefab, turretManager, mapController);
        }
    }

    private float CurrentDifficulty()
    {
        if (timeSinceStart < 10f)
        {
            return 0.75f;
        }
        else
        {
            return timeSinceStart / 10;
        }
    }
}
