using UnityEngine;

public class BulletPlayerDirection : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float shootInterval = 2f;

    private Transform player;
    private float nextFindTime;

    // Update is called once per frame
    void Update()
    {
        checkPlayerAndFire();
    }

    private void checkPlayerAndFire()
    {
        if (player == null)
        {
            if (Time.time >= nextFindTime)
            {
                player = GameObjectUtils.FindPlayer();
                nextFindTime = Time.time + shootInterval;
            }
            return;
        }

        // Only fire when cooldown elapsed.
        if (Time.time < nextFindTime)
            return;

        // Compute direction to player and set rotation so the bullet faces the player.
        Vector3 dir = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle);

        // Spawn bullet at this GameObject's position with the computed rotation.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, rot);
        }

        nextFindTime = Time.time + shootInterval;
    }
}
