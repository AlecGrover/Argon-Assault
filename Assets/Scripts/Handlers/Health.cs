using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;
    int health;
    bool invulnerable = false;
    [Tooltip("Time in seconds where object cannot take damage following a previous hit")]
    [SerializeField] float invulnerabilityTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public bool[] DealDamage(int damage)
    {
        if (invulnerable) { return new[] { false, false }; }
        StartCoroutine(InvulnerabilityTimer());
        health -= damage;
        return new[] { !(health > 0), true };
    }

    private IEnumerator InvulnerabilityTimer()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTimer);
        invulnerable = false;
    }
}
