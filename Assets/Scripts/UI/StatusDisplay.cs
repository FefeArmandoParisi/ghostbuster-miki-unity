using TMPro;
using UnityEngine;

public class StatusDisplay : MonoBehaviour
{
    private string statusText = "Status: ";
    private TMP_Text textComponent;
    private PlayerBase player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = statusText;
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

        SetStatusText(statusText + player.CheckStatus());
    }

    void SetStatusText(string value)
    {
        textComponent.text = value;
    }
}
