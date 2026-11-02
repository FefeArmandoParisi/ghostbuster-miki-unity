using System.Collections;
using UnityEngine;

public class EnemyEmitter : MonoBehaviour
{
    [SerializeField] private float spawnTime = 120f;
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private AudioClip spawnEnemySound;
    private float closeAnimationTime = 1f;
    private Animator animator;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        animator = GetComponent<Animator>();
    }

    private bool CanSpawnEnemy()
    {
        return GameObject.FindGameObjectsWithTag(GameConstants.EnemyTag).Length < GameConstants.maxEnemiesOnScreen;
    }

    private IEnumerator CloseEye()
    {
        yield return new WaitForSeconds(closeAnimationTime);

        animator.SetBool(GameConstants.enemyEmitterOpen, false);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            while (!CanSpawnEnemy())
            {
                yield return null;
            }

            if (spawnEnemySound != null)
            {
                AudioSource.PlayClipAtPoint(spawnEnemySound, transform.position);
            }
            CreateEnemy();
        }

    }

    private void CreateEnemy()
    {
        animator.SetBool(GameConstants.enemyEmitterOpen, true);
        Instantiate(enemyObject, transform.position, transform.rotation);
        StartCoroutine(CloseEye());
    }
}
