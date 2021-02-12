using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 1)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--;
    }

}
