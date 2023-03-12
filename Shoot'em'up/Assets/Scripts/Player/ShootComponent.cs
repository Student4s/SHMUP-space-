using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] private Bullet[] bulletStorage;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenShoot = 0.1f;
    [SerializeField] private float currentTimeBetweenShoot = 0f;

    [SerializeField]public List<Bullet> bullets;

    [SerializeField]private int currentBulletID = 1;

    void Start()
    {
        bullets = new List<Bullet>();
    }


    void Update()
    {
        if (currentTimeBetweenShoot <= 0)
        {
            SpawnBullet(shootPoint);
            currentTimeBetweenShoot = timeBetweenShoot;
        }

        currentTimeBetweenShoot -= Time.deltaTime;
    }

    public void SpawnBullet(Transform spawnPoint)
    {
        bool isHave = false;
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].isActive)
            {
                if (bullets[i].bulletID == currentBulletID)
                {
                    isHave = true;
                    bullets[i].SetActive(true);
                    bullets[i].GetComponent<Transform>().position = spawnPoint.position;
                    bullets[i].GetComponent<Transform>().rotation = spawnPoint.rotation;
                    return;
                }
            }
        }

        if (!isHave)
        {
            CreateNewBullet(currentBulletID);
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].bulletID == currentBulletID)
                {
                    if (!bullets[i].isActive)
                    {
                        bullets[i].SetActive(true);
                        bullets[i].GetComponent<Transform>().position = spawnPoint.position;
                        bullets[i].GetComponent<Transform>().rotation = spawnPoint.rotation;
                    }
                }
            }
        }
    }

    public void CreateNewBullet(int bulletID)
    {
        Bullet newBullet = Instantiate(bulletStorage[bulletID]);
        newBullet.SetActive(false);
        bullets.Add(newBullet);
    }
}