using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject hitParticle;
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
                player.PowerDown();
                player.Damage(1); // TODO: replace hardcoded value
            }

            Vector2 hitPoint = GetComponent<Collider2D>().ClosestPoint(collider.transform.position);
            Instantiate(hitParticle, hitPoint, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}