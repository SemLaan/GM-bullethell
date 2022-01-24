using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    [SerializeField] private GameObject flashingObject;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float minExplosionTime;
    [SerializeField] private float maxExplosionTime;
    [SerializeField] private float flashingSpeed = 10f;
    [SerializeField] private Color flashingColor;
    [SerializeField] private Color notFlashingColor;
    [SerializeField] private float bulletSpeed;
    private SpriteRenderer flashingRenderer;
    private float timeSinceExistance = 0f;
    private float flashingTimer = 0f;
    private float explosionTime;
    private bool flashing = false;

    private void Awake()
    {
        explosionTime = Random.Range(minExplosionTime, maxExplosionTime);
        flashingRenderer = flashingObject.GetComponent<SpriteRenderer>();
        flashingRenderer.color = notFlashingColor;
    }

    private void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = rigidbody.velocity.normalized * bulletSpeed;
    }

    private void FixedUpdate()
    {
        timeSinceExistance += Time.fixedDeltaTime;
        flashingTimer += Time.fixedDeltaTime;

        float flashSpeed = (explosionTime - timeSinceExistance) / flashingSpeed;

        // Checking if an individual bullet should be launched
        if (flashingTimer >= 1f * flashSpeed)
        {
            flashingTimer -= 1f * flashSpeed;
            FlipColor();
        }

        if (timeSinceExistance > explosionTime)
        {
            Explode();
        }
    }

    private void FlipColor()
    {
        if (flashing)
        {
            flashingRenderer.color = flashingColor;
        }
        else
        {
            flashingRenderer.color = notFlashingColor;
        }
        flashing = !flashing;
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
