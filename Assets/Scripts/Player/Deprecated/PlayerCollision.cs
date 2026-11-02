// DEPRECATED
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private int hitFlashFrames = 20;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private PlayerBase player;

    private void Awake() // Awake runs during load time.
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        player = GetComponent<PlayerBase>();
    }

    private IEnumerator FlashRedForFrames(int frames)
    {
        spriteRenderer.color = Color.red;

        for (int i = 0; i < frames; i++)
            yield return null; // wait 1 frame

        spriteRenderer.color = originalColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.CompareTag(GameConstants.EnemyTag))
        {
            if (player.CheckStatus() != GameConstants.PlayerStatus.Hurt)
            {
                StartCoroutine(FlashRedForFrames(hitFlashFrames));
            }
        }
    }


}
