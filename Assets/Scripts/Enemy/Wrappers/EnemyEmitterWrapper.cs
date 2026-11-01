using UnityEngine;

public class EnemyEmitterWrapper : MonoBehaviour
{
    [SerializeField] private GameObject enemyEmitterObject;

    private void Update()
    {
        enemyEmitterObject.SetActive(LevelState.Instance.EnemySpawn);
    }
}