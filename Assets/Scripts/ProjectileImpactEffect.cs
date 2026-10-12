using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileImpactEffect : MonoBehaviour
{
    public GameObject impactEffectPrefab;

    private bool effectPlayed = false;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name);
        Debug.Log("Checking impact effect prefab...");

        if (effectPlayed) return;

        if (impactEffectPrefab == null)
        {
            Debug.LogError("Impact Effect Prefab is NOT assigned!");
            return;
        }

        effectPlayed = true;

        ContactPoint contact = collision.GetContact(0);

        GameObject effect = Instantiate(
            impactEffectPrefab,
            contact.point,
            Quaternion.identity
        );

        Debug.Log("Effect created at: " + contact.point);

        ParticleSystem particles = effect.GetComponent<ParticleSystem>();

        if (particles != null)
        {
            particles.Play();
            Debug.Log("Particle System played!");
        }
        else
        {
            Debug.LogWarning("No Particle System found on the prefab's root!");
        }
    }
}
