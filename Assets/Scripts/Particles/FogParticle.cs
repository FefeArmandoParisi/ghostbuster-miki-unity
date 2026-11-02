using UnityEngine;

public class FogParticle : MonoBehaviour
{
    private const float Duration = 1f;
    private SpriteRenderer sprite;
    private Vector3 startScale;
    private float startAlpha;
    private float elapsed;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
        startAlpha = sprite.color.a;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;

        // If more time has passed than the Duration specified, destroy the particle
        if (elapsed >= Duration)
        {
            Destroy(gameObject);
            return;
        }

        float t = elapsed / Duration;

        transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

        Color color = sprite.color;
        color.a = Mathf.Lerp(startAlpha, 0f, t);
        sprite.color = color;
    }
}
