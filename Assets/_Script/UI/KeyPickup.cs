using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerKey playerKey = other.GetComponent<PlayerKey>();
        if (playerKey == null) return;
        if (playerKey.AddKey())
        {
            Destroy(gameObject);
        }
    }
}
