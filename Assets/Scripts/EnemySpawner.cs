using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 1.75f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;
    int spawnedEnemiesCount;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = spawnedEnemiesCount.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) //forever - gameloop
        {
            IncreaseScore();

            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); //create a new enemy object
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }

    }

    private void IncreaseScore()
    { 
        spawnedEnemiesCount++;
        spawnedEnemies.text = spawnedEnemiesCount.ToString();
    }
}
