using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyingBullet : BaseBullet
{
    [SerializeField] private GameObject basicBulletPrefab;
    [SerializeField] private float bulletLuanchTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float launchedBulletSpeed;
    private new Rigidbody2D rigidbody;
    private float bulletLaunchTimer = 0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = rigidbody.velocity.normalized * bulletSpeed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        bulletLaunchTimer += Time.fixedDeltaTime;
        if (bulletLaunchTimer >= bulletLuanchTime)
        {
            bulletLaunchTimer -= bulletLuanchTime;
            CreateBullet(transform.up);
            CreateBullet(-transform.up);
            CreateBullet(transform.right);
            CreateBullet(-transform.right);
        }
    }

    private void CreateBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(basicBulletPrefab, transform.position, transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = launchedBulletSpeed * direction;
    }
}
