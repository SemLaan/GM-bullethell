using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    [SerializeField] private Color warningColor;
    private Color defaultColor;
    private new SpriteRenderer renderer;
    private List<GameObject> loadedBullets;
    private List<float> bulletWaitTimes;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        defaultColor = renderer.color;
        loadedBullets = new List<GameObject>();
        bulletWaitTimes = new List<float>();
    }

    public void QueueBullet(GameObject bullet, float waitTime)
    {
        loadedBullets.Add(bullet);
        bulletWaitTimes.Add(waitTime);
        renderer.color = warningColor;
    }

    private void CreateBullet(GameObject bulletPrefab)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = 50 * transform.up;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < loadedBullets.Count; i++)
        {
            bulletWaitTimes[i] -= Time.fixedDeltaTime;
            if (bulletWaitTimes[i] <= 0)
            {
                CreateBullet(loadedBullets[i]);
                bulletWaitTimes.RemoveAt(i);
                loadedBullets.RemoveAt(i);
                if (loadedBullets.Count == 0)
                {
                    renderer.color = defaultColor;
                }
            }
        }
    }
}
