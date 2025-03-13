using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private Vector3 playerPos;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHp = other.GetComponent<Health>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(1);
                other.transform.position = playerPos;
            }
        }
    }
}
