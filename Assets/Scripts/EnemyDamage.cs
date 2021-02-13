using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticalePrefab;
    [SerializeField] ParticleSystem deathParticalePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDiesSFX;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        hitParticalePrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyDamageSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticalePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx, vfx.main.duration);

        AudioSource.PlayClipAtPoint(enemyDiesSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }



}
