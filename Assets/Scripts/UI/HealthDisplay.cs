using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private string healthText = "Health: ";
    private TMP_Text textComponent;
    private PlayerBase player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = healthText;
    }

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        GameObject playerObject = GameObject.FindGameObjectWithTag(GameConstants.TagPlayer);

        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerBase>();
        }
    }

    // Update is called once per frame
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
