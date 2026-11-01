using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private GameObject bossObject;
    private BossBase boss;

    void Start()
    {
        boss = bossObject.GetComponent<BossBase>();
    }

    void Update()
    {
        if (healthBarSlider != null && bossObject != null && boss != null)
        {
            int currentHealth = boss.CurrentHealth();
            int maxHealth = boss.MaxHealth;
            healthBarSlider.value = maxHealth > 0 ? (float)currentHealth / maxHealth : 0f;
        }
    }
}
