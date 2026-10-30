using TMPro;
using UnityEngine;

public class CreditsDisplay : MonoBehaviour
{
    private string creditsText = "Credits: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = creditsText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetCreditsText(creditsText + player.CheckRemainingCredits());
    }

    void SetCreditsText(string value)
    {
        textComponent.text = value;
    }
}
