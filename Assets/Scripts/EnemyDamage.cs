﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticalePrefab;
    [SerializeField] ParticleSystem deathParticalePrefab;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticalePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--;
        hitParticalePrefab.Play();
    }

}
