using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private GameObject bossObject;
    private BossBase boss;

    private void Start()
    {
        boss = bossObject.GetComponent<BossBase>();
    }

    private void Update()
    {
        if (healthBarSlider != null && bossObject != null && boss != null)
        {
            int currentHealth = boss.CurrentHealth();
            int maxHealth = boss.MaxHealth;
            if (maxHealth > 0)
            {
                float bossHealthValue = (float)currentHealth / maxHealth;
                healthBarSlider.value = bossHealthValue;
            }
            else
            {
                healthBarSlider.value = 0f;
            }
        }
    }
}
