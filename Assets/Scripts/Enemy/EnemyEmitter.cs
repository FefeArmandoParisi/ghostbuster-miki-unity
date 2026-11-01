using System.Collections;
using UnityEngine;

public class EnemyEmitter : MonoBehaviour
{
    [SerializeField] private float spawnTime = 120f;
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private AudioClip spawnEnemySound;
    private float closeAnimationTime = 1f;
    private Animator animator;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        animator = GetComponent<Animator>();
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

            if (spawnEnemySound != null)
            {
                AudioSource.PlayClipAtPoint(spawnEnemySound, transform.position);
            }
            CreateEnemy();
        }

    }

    bool CanSpawnEnemy()
    {
        return GameObject.FindGameObjectsWithTag(GameConstants.EnemyTag).Length < GameConstants.maxEnemiesOnScreen;
    }

    private IEnumerator CloseEye()
    {
        yield return new WaitForSeconds(closeAnimationTime);

        animator.SetBool("open", false);
    }

    void CreateEnemy()
    {
        animator.SetBool("open", true);
        Instantiate(enemyObject, transform.position, transform.rotation);
        StartCoroutine(CloseEye());
    }
}
