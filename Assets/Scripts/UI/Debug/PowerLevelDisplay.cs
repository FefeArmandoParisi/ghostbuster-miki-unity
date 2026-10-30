using TMPro;
using UnityEngine;

public class PowerLevelDisplay : MonoBehaviour
{
    private string powerLevelText = "Power: ";
    private TMP_Text textComponent;
    private PlayerBase player;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = powerLevelText;
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        SetPowerLevelText(powerLevelText + player.CheckPowerLevel());
    }

    void SetPowerLevelText(string value)
    {
        textComponent.text = value;
    }
}
