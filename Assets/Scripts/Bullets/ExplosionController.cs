using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private float timeSinceExistance = 0f;
    private float maxExistanceTime = 1f;

    private void FixedUpdate()
    {
        timeSinceExistance += Time.fixedDeltaTime;
        if (timeSinceExistance > maxExistanceTime)
        {
            Destroy(gameObject);
        }
    }
}
