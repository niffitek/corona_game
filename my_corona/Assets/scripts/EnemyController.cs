using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Initialisierung der Variablen
    public GameObject enemy;
    public GameObject enemyshooter;


    public float spawnRate;
    public float shooterSpawnRate;
    private float nextSpawn = 0.0f;
    private float nextSpawn_ = 0f;

    public bool enableShooter;

    //Diese Funktion startet alle Routinen im ersten Frame
    void Start()
    {
        StartCoroutine(IncreaseSpawnRate());
        StartCoroutine(EnableShooter());
        StartCoroutine(IncreaseSpawnRate_());
    }

    //Diese Funktion lässt die zwei Gegnertypen auf einer festgelegten y und z Höhe instanzieren. Der x Bereich wird zufällig (von -9 bis 9) gewählt.
    void Update()
    {      
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject go = (GameObject)Instantiate(enemy,
            new Vector3(Random.Range(-9.0f, 9.0f), 6, 10), Quaternion.identity);
            go.SetActive(true);
            go.GetComponent<EnemyController>().isClone = true;
        }

        if (enableShooter)
        {
            if (Time.time > nextSpawn_)
            {
                nextSpawn_ = Time.time + shooterSpawnRate;
                GameObject go_ = (GameObject)Instantiate(enemyshooter,
                new Vector3(Random.Range(-6.0f, 6.0f), 6, 10), Quaternion.identity);
                go_.SetActive(true);
                go_.GetComponent<EnemyShooterController>().isClone = true;
            }
        }

    }
    //Diese Funktion erhöht langsam die Spawnrate bis zu einem bestimmten Wert (Rekursion) (für normale Gegner)
    IEnumerator IncreaseSpawnRate()
    {
        yield return new WaitForSeconds(1);
        spawnRate -= 0.002f;
        if (spawnRate >= 0.175)
        {
        StartCoroutine(IncreaseSpawnRate());
        }
    }
    //Diese Funktion erhöht langsam die Spawnrate bis zu einem bestimmten Wert (Rekursion) (für schießende Gegner)
    IEnumerator IncreaseSpawnRate_()
    {
        yield return new WaitForSeconds(1);
        shooterSpawnRate -= 0.05f;
        if (shooterSpawnRate >= 1f)
        {
            StartCoroutine(IncreaseSpawnRate_());
        }
    }
    //Die Funktion lässt nach 5 Sekunden zu, dass schießende Gegner erscheinen.
    IEnumerator EnableShooter()
    {
        yield return new WaitForSeconds(5f);
        enableShooter = true;
    }

}
