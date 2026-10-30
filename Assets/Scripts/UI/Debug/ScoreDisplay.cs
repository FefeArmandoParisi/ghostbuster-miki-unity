using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private string scoreLevelText = "Score: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = scoreLevelText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetScoreLevelText(scoreLevelText + "Score not available yet!");
    }

    void SetScoreLevelText(string value)
    {
        textComponent.text = value;
    }
}