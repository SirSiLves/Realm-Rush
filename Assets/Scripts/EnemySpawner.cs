using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 4f;
    [SerializeField] EnemyMovement enemyPrefab;


    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) //forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity); //create a new enemy object
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }

    }

}
