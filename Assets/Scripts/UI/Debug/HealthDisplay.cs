using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private string healthText = "Health: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = healthText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetHealthText(healthText + player.CheckHealth());
    }

    void SetHealthText(string value)
    {
        textComponent.text = value;
    }
}
