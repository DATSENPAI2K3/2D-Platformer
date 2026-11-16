using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private GameObject healthPickupPrefab;
    [SerializeField] private Vector3 spawnOffset = new Vector3(0f, 1f, 0f);
    [SerializeField] private float popForce = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerKey playerKey = collision.gameObject.GetComponent<PlayerKey>();
        if (playerKey == null) return;
        if (!playerKey.UseKey()) return;
        SpawnPickup();
        Destroy(gameObject);
    }
    private void SpawnPickup()
    {
        GameObject pickup = Instantiate(healthPickupPrefab, transform.position + spawnOffset, Quaternion.identity);
        pickup.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, popForce);
    }
}
