using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject basicBulletPrefab;
    [SerializeField] private GameObject otherBulletPrefab;
    [Header("Bullet patterns")]
    [SerializeField] private bool row;
    [SerializeField] private bool rowWithHole;
    [SerializeField] private bool cheeseGrater;
    [Header("Bullets per second")]
    [SerializeField] private float maxBulletDifficulty;
    [Header("Bullet patterns per second")]
    [SerializeField] private float maxPatternDifficulty;
    private TurretManager turretManager;
    private MapController mapController;
    private List<IPattern> bulletPatterns;

    private float timeSinceStart = 0f;
    private float patternTimer = 0f;
    private float bulletTimer = 0f;

    private void Awake()
    {
        turretManager = FindObjectOfType<TurretManager>();
        mapController = FindObjectOfType<MapController>();
        bulletPatterns = new List<IPattern>();
        if (row)
            bulletPatterns.Add(new RowPattern());
        if (rowWithHole)
            bulletPatterns.Add(new RowWithHolePattern());
        if (cheeseGrater)
            bulletPatterns.Add(new CheeseGraterPattern());
    }

    private void FixedUpdate()
    {
        // Getting the current difficulty and updating all the timers
        float difficulty = CurrentDifficulty();
        float bulletDifficulty = difficulty > maxBulletDifficulty ? maxBulletDifficulty : difficulty;
        float patternDifficulty = difficulty > maxPatternDifficulty ? maxPatternDifficulty : difficulty;
        timeSinceStart += Time.fixedDeltaTime;
        patternTimer += Time.fixedDeltaTime;
        bulletTimer += Time.fixedDeltaTime;
        // Checking if an individual bullet should be launched
        if (bulletTimer >= 1f / bulletDifficulty)
        {
            bulletTimer -= 1f / bulletDifficulty;
            turretManager.LaunchBullet(otherBulletPrefab);
        }
        // Checking if a pattern should be launched
        if (patternTimer >= 2f / patternDifficulty)
        {
            patternTimer -= 2f / patternDifficulty;
            bulletPatterns[Random.Range(0, bulletPatterns.Count)].CreateBulletPattern(6, basicBulletPrefab, turretManager, mapController);
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
