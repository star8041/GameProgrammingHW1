using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount;
    public float enemyLifetime;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = Vector3.zero;
            bool validSpawn = false;
            GameObject enemy;

            while (!validSpawn)
            {
                float randomDistance = Random.Range(minDistance, maxDistance);
                float randomAngle = Random.Range(0f, Mathf.PI * 2);

                spawnPosition = new Vector3(
                    playerTransform.position.x + randomDistance * Mathf.Cos(randomAngle),
                    playerTransform.position.y + 4f,
                    playerTransform.position.z + randomDistance * Mathf.Sin(randomAngle)
                );

                Collider[] collider = Physics.OverlapBox(spawnPosition, new Vector3(1f, 1f, 1f));
                if (collider.Length == 0)
                {
                    validSpawn = true;
                }
            }

            enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Destroy(enemy, enemyLifetime);
            //enemy.AddComponent<RandomMovement>();


            yield return new WaitForSeconds(3f);
        }
    }
}
