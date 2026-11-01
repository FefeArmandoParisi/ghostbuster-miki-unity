using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private GameObject deathAnimation;
    [SerializeField] private int powerUpDropChanceDenominator = 20;
    [SerializeField] private AudioClip enemyHitSound;
    [SerializeField] private AudioClip playerHitSound;
    private int hitFlashFrames = 6;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (LevelState.Instance.BossDefeated)
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            Destroy(collider.gameObject);
            health--;
            if (enemyHitSound != null)
            {
                AudioSource.PlayClipAtPoint(enemyHitSound, transform.position);
            }

            if (health <= 0)
            {
                TrySpawnPowerUp();
                Instantiate(deathAnimation, transform.position, Quaternion.identity);
                LevelState.Instance.RegisterEnemyDefeated();
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(FlashRedForFrames(hitFlashFrames));
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.CompareTag("Player"))
        {
            PlayerBase player = collider.GetComponent<PlayerBase>();
            if (player.CheckStatus() == GameConstants.PlayerStatus.Hurt)
            {
                return;
            }
            else
            {
                if (playerHitSound != null)
                {
                    AudioSource.PlayClipAtPoint(playerHitSound, transform.position);
                }
                player.PowerDown();
                player.Damage(damageAmount);
            }
        }
    }

    private IEnumerator FlashRedForFrames(int frames)
    {
        spriteRenderer.color = Color.red;

        for (int i = 0; i < frames; i++)
            yield return null; // wait 1 frame

        spriteRenderer.color = originalColor;
    }

    private void TrySpawnPowerUp()
    {
        if (powerUpPrefab == null)
        {
            return;
        }

        if (Random.Range(0, powerUpDropChanceDenominator) == 0)
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
