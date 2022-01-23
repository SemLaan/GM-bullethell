using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected float timeSinceExistance = 0f;
    protected float maxExistanceTime = 8f;

    private void FixedUpdate()
    {
        timeSinceExistance += Time.fixedDeltaTime;
        if (timeSinceExistance > maxExistanceTime)
        {
            Destroy(gameObject);
        }
    }
}
