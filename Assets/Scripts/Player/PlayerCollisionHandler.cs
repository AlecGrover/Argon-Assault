using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    enum CollisionResult
    {
        loseLifeAndRespawn,
        killPlayer,
        loseLifeAndContinue
    }

    bool playerIsAlive = true;

    [Header("Collision Behaviour")]
    [SerializeField] CollisionResult terrainCollisionResult = CollisionResult.killPlayer;
    [SerializeField] CollisionResult enemyCollisionResult = CollisionResult.loseLifeAndContinue;


    private void OnTriggerEnter(Collider other)
    {
        ProcessPlayerDeath();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ProcessPlayerDeath();
    }

    private void ProcessPlayerDeath()
    {
        if (!playerIsAlive) { return; }
        DisableControls();
        TriggerExplosionsEffects();
        StartCoroutine(DestroyShip());
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

    private void DisableControls()
    {
        playerIsAlive = false;
        Player player = FindObjectOfType<Player>();
        if (player)
        {
            player.KillPlayer();
        }
    }

    private IEnumerator DestroyShip()
    {
        yield return new WaitForSeconds(0.5f);
        DisableRenderedMesh();
        DisableWeapons();
        CallLevelLoader();
    }

    private void DisableWeapons()
    {
        GameObject weapons = transform.Find("Weapons").gameObject;
        if (weapons)
        {
            weapons.SetActive(false);
        }
    }

    private void DisableRenderedMesh()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            meshRenderer.enabled = false;
        }
    }

    private void CallLevelLoader()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        // Debug.Log("Looking for level loader");
        if (levelLoader)
        {
            // Debug.Log("level loader found");
            StartCoroutine(levelLoader.DelayedLoadNextLevel(1f));
        }
    }
}
