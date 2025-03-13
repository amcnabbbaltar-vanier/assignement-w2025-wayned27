using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHp = collision.gameObject.GetComponent<Health>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(damage);
            }
        }
    }
}
