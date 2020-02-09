using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ennemy;
    [SerializeField] private List<Transform> spawns;
    [SerializeField] private GameObject deathAnim;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRateBuff;
    [SerializeField] private float minSpawnRate;
    [SerializeField] private float ennemySpeed;
    [SerializeField] private float ennemySpeedBuff;
    [SerializeField] private float maxEnnemySpeed;
    [SerializeField] private Vector2 numberOfEnnemies;

    private float remainingSpawnTime;

    private void Start()
    {
        DifficultyIncrease.instance.onDifficultyIncrease += DifficultyIncreaseHandler;
    }

    private void OnDisable()
    {
        DifficultyIncrease.instance.onDifficultyIncrease += DifficultyIncreaseHandler;
    }

    private void DifficultyIncreaseHandler()
    {
        if (spawnRate > minSpawnRate)
        {
            spawnRate -= spawnRateBuff;
        }

        if (ennemySpeed < maxEnnemySpeed)
        {
            ennemySpeed += ennemySpeedBuff;
        }
    }

    private void Update()
    {
        Cooldown();
    }

    private void Cooldown()
    {
        remainingSpawnTime += Time.deltaTime;
        if (remainingSpawnTime >= spawnRate)
        {
            SpawnEnnemy();
            remainingSpawnTime = 0;
        }
    }

    private void SpawnEnnemy()
    {
        int number = UnityEngine.Random.Range((int)numberOfEnnemies.x, (int)numberOfEnnemies.y);

        for (int i = 0; i < number; i++)
        {
            int random = UnityEngine.Random.Range(0, spawns.Count);
            int secondRandom = UnityEngine.Random.Range(0, ennemy.Count);
            GameObject newEnnemy = Pool.instance.GetItemFromPool(ennemy[secondRandom], spawns[random].position, Quaternion.identity);
            newEnnemy.GetComponent<EnnemyBehaviour>().Initialize(ennemySpeed, deathAnim);
        }
    }
}
