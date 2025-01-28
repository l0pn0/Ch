using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private bool isCaught = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Объект пойман!");
            isCaught = true;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (!isCaught)
        {
            Debug.Log("Объект пропущен!");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                HealthManager healthManager = player.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
