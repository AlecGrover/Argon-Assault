using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        TriggerExplosionsEffects();
        StartCoroutine(DestroyGameObject());
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
}
