using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerAsteroids : MonoBehaviour
{
    [SerializeField] private float screenWidth = 2f;

    [SerializeField] private StandartAsteroids asteroid;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawn = 0.4f;
    [SerializeField] private float currentTimeBetweenSpawn = 0f;

    public List<StandartAsteroids> asteroids;
    [SerializeField]private Transform target;
    public List<Preset> preset =new ();

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        if (currentTimeBetweenSpawn <= 0)
        {
            Transform newSpawnPoint = spawnPoint;
            newSpawnPoint.position =
                new Vector3(Random.Range(-screenWidth, screenWidth), newSpawnPoint.position.y,
                    newSpawnPoint.position.z);
            int random = Random.Range(0, preset.Count);
            SpawnAsteroid(newSpawnPoint,random);
            currentTimeBetweenSpawn = timeBetweenSpawn;
        }
        currentTimeBetweenSpawn -= Time.deltaTime;
    }

    public void SpawnAsteroid(Transform spawnPoint, int asteroidIndex)
    {
        bool isHave = false;
        for (int i = 0; i < asteroids.Count; i++)
        {
            if (!asteroids[i].isActive)
            {
                if (asteroids[i].asteroidType == asteroidIndex)
                {
                    isHave = true;
                    asteroids[i].SetActive(true);
                    asteroids[i].GetComponent<Transform>().position = spawnPoint.position;
                    asteroids[i].GetComponent<Transform>().rotation = spawnPoint.rotation;
                    return;
                }
            }
        }

        if (!isHave)
        {
            CreateNewAsteroid(asteroidIndex);
            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].asteroidType == asteroidIndex)
                {
                    if (!asteroids[i].isActive)
                    {
                        asteroids[i].SetActive(true);
                        asteroids[i].GetComponent<Transform>().position = spawnPoint.position;
                        asteroids[i].GetComponent<Transform>().rotation = spawnPoint.rotation;
                    } 
                }
            }
        }
    }

    public void CreateNewAsteroid(int index)
    {
        StandartAsteroids newAsteroid = Instantiate(asteroid);
        newAsteroid.SetParameter(preset[index].speed,preset[index].rotationSpeed,target,preset[index].magnitePower,preset[index].acceleration,preset[index].type);
        newAsteroid.SetMaterial(index);
        newAsteroid.SetActive(false);
        asteroids.Add(newAsteroid);
    }
}

[Serializable] 
public struct Preset
{
    public float speed;
    public float rotationSpeed;
    public float magnitePower;
    public float acceleration;
    public int type;
}