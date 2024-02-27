using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5; // Maximum number of enemies to have simultaneously
    public float spawnInterval = 3f;
    public float spawnDistance = 10f;

    private Transform playerTransform;
    private float timer = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnInitialEnemies();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * spawnDistance;
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.GetComponent<EnemyHealth>().OnEnemyDestroyed.AddListener(OnEnemyDestroyed);
        }
    }

    void OnEnemyDestroyed()
    {
        // Called when an enemy is destroyed
        SpawnEnemy();
    }
}
