using System.Collections;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject deathAnimation;
    private int hitFlashFrames = 6;
    private float deathAnimationSpawnTime = 0.5f;
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
            StartCoroutine(SpawnDeathSprite());
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            Destroy(collider.gameObject);
            health--;

            if (health <= 0)
            {
                LevelState.Instance.SetBossDefeated(true);
                LevelState.Instance.SetInputLocked(true);
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

    private IEnumerator SpawnDeathSprite()
    {
        Instantiate(deathAnimation, GetRandomSpawnPosition(), Quaternion.identity);
        yield return new WaitForSeconds(deathAnimationSpawnTime);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Creates a boundary that extends through the sprite max height and width
        Bounds bounds = spriteRenderer.bounds;
        // Looks for a random point with the range, which then communicates through the return
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector3(x, y, transform.position.z);
    }
}
