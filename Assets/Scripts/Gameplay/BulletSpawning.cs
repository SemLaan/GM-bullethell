using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawning : MonoBehaviour
{
    private TurretManager turretManager;
    [SerializeField] private GameObject basicBulletPrefab;

    private float timer = 0f;

    private void Awake()
    {
        turretManager = FindObjectOfType<TurretManager>();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= 0.2)
        {
            timer -= 0.2f;
            turretManager.LaunchBullet(basicBulletPrefab);
        }
    }
}
