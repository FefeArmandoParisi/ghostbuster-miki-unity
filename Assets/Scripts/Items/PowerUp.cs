using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerBase player = collider.GetComponent<PlayerBase>();
            player.PowerUp();
            Destroy(gameObject);
        }
    }
}
