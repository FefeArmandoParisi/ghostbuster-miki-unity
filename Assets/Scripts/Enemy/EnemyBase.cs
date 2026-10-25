using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private int powerUpDropChanceDenominator = 20;
    //
    private int hitFlashFrames = 6;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public int DamageAmount => damageAmount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Entered Trigger");
        if (collider.CompareTag("PlayerBullet"))
        {
            Destroy(collider.gameObject);
            health--;

            if (health <= 0)
            {
                TrySpawnPowerUp();
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(FlashRedForFrames(hitFlashFrames));
            }
        }
        else if (collider.CompareTag("EnemyDestroyer"))
        {
            Destroy(gameObject);
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
