using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health;
    private int hitFlashFrames = 6;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private IEnumerator FlashRedForFrames(int frames)
    {
        spriteRenderer.color = Color.red;

        for (int i = 0; i < frames; i++)
            yield return null; // wait 1 frame

        spriteRenderer.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            if (health <= 0)
            {
                Destroy(collider.gameObject);
                Destroy(gameObject);

            }
            else
            {
                Destroy(collider.gameObject);
                health--;
                StartCoroutine(FlashRedForFrames(hitFlashFrames));
            }

        }
    }
}
