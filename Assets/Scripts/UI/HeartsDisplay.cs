using System.Collections.Generic;
using UnityEngine;

public class HeartsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject healthUnit;
    private PlayerBase player;
    private int heartsNumber;
    private float healthUnitWidth = 0.32f;
    private string[] healthArray;
    private List<HealthUnit> healthUnits = new List<HealthUnit>();
    private int lastHealth;

    private void Start()
    {
        player = GameObjectUtils.FindPlayer();

        if (healthUnit == null || player == null)
        {
            return;
        }

        heartsNumber = player.CheckMaxHealth();
        healthArray = new string[heartsNumber]; //Generate an array based on the max number of hearts

        for (int i = 0; i < heartsNumber; i++) //Go through the max number of hearts and draw them one by one
        {
            healthArray[i] = GameConstants.HeartFilled;

            Vector3 position = transform.position + new Vector3(i * healthUnitWidth * 4, 0f, 0f);
            GameObject unitObject = Instantiate(healthUnit, position, Quaternion.identity, transform);
            healthUnits.Add(unitObject.GetComponent<HealthUnit>());
        }
    }

    private void Update()
    {
        if (player == null || healthUnit == null)
        {
            return;
        }

        int currentHealth = player.CheckHealth();

        if (currentHealth == lastHealth)
        {
            return;
        }

        if (currentHealth < lastHealth)
        {
            // On taking damage unfill from the rightmost filled heart toward the left
            for (int i = lastHealth - 1; i >= currentHealth; i--)
            {
                healthUnits[i].SubstractHeart();
            }
        }
        else
        {
            // UNUSED: On reset refill from the leftmost empty heart toward the right
            for (int i = lastHealth; i < currentHealth; i++)
            {
                healthUnits[i].RestoreHeart();
            }
        }

        lastHealth = currentHealth;
    }
}
