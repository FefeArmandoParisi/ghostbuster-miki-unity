using UnityEngine;

public class EnemyEmitterWrapper : MonoBehaviour
{
    [SerializeField] private GameObject enemyEmitterObject;
    private void Start()
    {
        Debug.Log($"Defeat {LevelState.Instance.EnemiesToDefeat} enemies to clear this level.");
        Debug.Log($"EnemySpawn is {LevelState.Instance.EnemySpawn}");
    }

    private void Update()
    {
        enemyEmitterObject.SetActive(LevelState.Instance.EnemySpawn);
    }
}