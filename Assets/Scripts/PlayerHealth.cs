using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    public static event Action OnPlayerDied;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy) {
            getHurt();
        }
    }

    private void getHurt() {
        currentHealth--;
        if (currentHealth == 0) {
            OnPlayerDied.Invoke();
            Destroy(gameObject);
        }
    }
}
