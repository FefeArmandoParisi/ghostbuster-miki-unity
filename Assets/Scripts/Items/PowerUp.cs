using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float removeAfterSeconds = 10;
    [SerializeField] private AudioClip collisionSound;

    private void Start()
    {
        StartCoroutine(RemovePowerUp());
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(GameConstants.PlayerTag))
        {

            PlayerBase player = collider.GetComponent<PlayerBase>();
            player.PowerUp();
            if (collisionSound != null)
            {
                AudioSource.PlayClipAtPoint(collisionSound, transform.position);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator RemovePowerUp()
    {
        yield return new WaitForSeconds(removeAfterSeconds);

        Destroy(gameObject);
    }
}
