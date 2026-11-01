using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private TMP_Text textComponent;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        int enemiesDefeated;
        if (LevelState.Instance.EnemiesDefeated > LevelState.Instance.EnemiesToDefeat)
        {
            // If number if enemies defeated is more than the quota 
            // (can happen if there are some enemies lingering in the screen) 
            // default to maxNumer of enemies to defeat
            enemiesDefeated = LevelState.Instance.EnemiesToDefeat;
        }
        else
        {
            enemiesDefeated = LevelState.Instance.EnemiesDefeated;
        }

        SetCounterText($"{enemiesDefeated} / {LevelState.Instance.EnemiesToDefeat}");
    }

    void SetCounterText(string value)
    {
        textComponent.text = value;
    }
}
