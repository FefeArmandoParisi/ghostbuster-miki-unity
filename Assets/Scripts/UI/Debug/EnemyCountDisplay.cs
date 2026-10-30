using TMPro;
using UnityEngine;

public class EnemyCountDisplay : MonoBehaviour
{
    private string enemyCountLevelText = "EnemyCount: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = enemyCountLevelText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetEnemyCountLevelText(enemyCountLevelText + $"{LevelState.Instance.EnemiesDefeated} / {LevelState.Instance.EnemiesToDefeat}");
    }

    void SetEnemyCountLevelText(string value)
    {
        textComponent.text = value;
    }
}