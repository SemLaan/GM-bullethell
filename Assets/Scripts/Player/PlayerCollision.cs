using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask bulletLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletLayer == (bulletLayer | (1 << collision.gameObject.layer)))
        {
            print("collided with bullet");
        }
    }
}
