using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    // Start is called before the first frame update
public void SetWeaponsActive(bool weaponsFiring)
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            var em = particleSystem.emission;
            em.enabled = weaponsFiring;
        }
    }
}
