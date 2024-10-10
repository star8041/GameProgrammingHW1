using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount;
    public Vector3 spawnArea;
    public float enemyLifetime;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < spawnCount; i++)
        //{
        //    Vector3 spawnPosition = new Vector3(
        //        Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
        //        spawnArea.y,
        //        Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        //    );

        //    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        //    //enemy.AddComponent<RandomMovement>();

        //    Destroy(enemy, enemyLifetime);

        //    yield return new WaitForSeconds(3f);
        //}
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                spawnArea.y,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            spawnPosition += transform.position;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //enemy.AddComponent<RandomMovement>();

            Destroy(enemy, enemyLifetime);

            yield return new WaitForSeconds(3f);
        }
    }
}
