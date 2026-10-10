using System.Collections;
using UnityEngine;

public class EnemyEmitter : MonoBehaviour
{
    [SerializeField] private float spawnTime = 120f;
    [SerializeField] private GameObject enemyObject;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            while (!CanSpawnEnemy())
            {
                yield return null;
            }


            CreateEnemy();
        }

    }

    bool CanSpawnEnemy()
    {
        return GameObject.FindGameObjectsWithTag(GameConstants.EnemyTag).Length < GameConstants.maxEnemiesOnScreen;
    }

    void CreateEnemy()
    {
        Instantiate(enemyObject, transform.position, transform.rotation);
    }
}
