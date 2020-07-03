using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [Header("Score Rewards")]
    [SerializeField] int destroyReward = 100;
    [SerializeField] int damageReward = 50;

    bool alive = true;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!alive) { return; }
        bool[] dealtDamage = DealDamage();
        if (dealtDamage[0])
        {
            alive = false;
            StartCoroutine(DestroyGameObject());
        }
        TriggerExplosionsEffects();
        if (dealtDamage[1])
        {
            AwardPoints();
        }
    }

    private bool[] DealDamage()
    {
        Health health = GetComponent<Health>();
        if (!health) { return new[] { true, true }; }
        return health.DealDamage(50);
    }

    private void TriggerExplosionsEffects()
    {
        GameObject explosionEffect = transform.Find("Explosion").gameObject;
        if (explosionEffect)
        {
            ParticleSystem explosion = explosionEffect.GetComponent<ParticleSystem>();
            if (explosion)
            {
                explosion.Play();
            }
            AudioSource audioSource = explosionEffect.GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.Play();
            }
        }
    }

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void AwardPoints()
    {
        Scoreboard scoreboard = FindObjectOfType<Scoreboard>();
        if (!scoreboard) { return; }
        if (alive)
        {
            scoreboard.AddToScore(damageReward);
        }
        else
        {
            scoreboard.AddToScore(destroyReward);
        }
    }
}
