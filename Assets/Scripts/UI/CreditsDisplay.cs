using TMPro;
using UnityEngine;

public class CreditsDisplay : MonoBehaviour
{
    private string creditsText = "Credits: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = creditsText;
        player = GameObjectUtils.FindPlayer();
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        SetCreditsText(creditsText + player.CheckRemainingCredits());
    }

    private void SetCreditsText(string value)
    {
        textComponent.text = value;
    }
}
