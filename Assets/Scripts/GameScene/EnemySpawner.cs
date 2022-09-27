using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyInstance, PaperInstance, RockInstance, ScissorsInstance, HealthInstance, EnemyObject;
    private Enemy EnemyScript;
    public string EnemyType;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 2);
        InvokeRepeating("SpawnItem2", 1, 1);
    }

    void SpawnEnemy()
    {
        EnemyObject = Instantiate(EnemyInstance, transform.position + new Vector3(Random.Range(-8,8), 0, 0), Quaternion.identity);
        EnemyScript = EnemyObject.GetComponent<Enemy>();
        EnemyType = EnemyScript.GetEnemyType();
        SpawnItem(EnemyType);
    }

    public IEnumerator SpawnItemTimer(string EnemyType)
    {
        yield return new WaitForSeconds(2);
        switch (EnemyType)
        {
            case ("rock"):
                Instantiate(PaperInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
            case ("paper"):
                Instantiate(ScissorsInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
            case ("scissors"):
                Instantiate(RockInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
        }
    }

    void SpawnItem(string EnemyType)
    {
        StartCoroutine(SpawnItemTimer(EnemyType));
    }

    void SpawnItem2()
    {
        switch (Random.Range(0, 2))
        {
            case (0):
                Instantiate(RockInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
            case (1):
                Instantiate(PaperInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
            case (2):
                Instantiate(ScissorsInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
                break;
        }
    }

    public void SpawnHealth()
    {
        Instantiate(HealthInstance, transform.position + new Vector3(Random.Range(-8, 8), 0, 0), Quaternion.identity);
    }
}
