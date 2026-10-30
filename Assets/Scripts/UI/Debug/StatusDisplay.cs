using TMPro;
using UnityEngine;

public class StatusDisplay : MonoBehaviour
{
    private string statusText = "Status: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = statusText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetStatusText(statusText + player.CheckStatus());
    }

    void SetStatusText(string value)
    {
        textComponent.text = value;
    }
}
