using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float removeAfterSeconds = 10;

    private void Start()
    {
        StartCoroutine(RemovePowerUp());
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerBase player = collider.GetComponent<PlayerBase>();
            player.PowerUp();
            Destroy(gameObject);
        }
    }

    private IEnumerator RemovePowerUp()
    {
        yield return new WaitForSeconds(removeAfterSeconds);

        Destroy(gameObject);
    }
}
