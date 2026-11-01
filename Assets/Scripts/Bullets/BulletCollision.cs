using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (hitParticle == null)
        {
            return;
        }

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
                player.Damage(damage);
            }

            Vector2 hitPoint = GetComponent<Collider2D>().ClosestPoint(collider.transform.position);
            Instantiate(hitParticle, hitPoint, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}