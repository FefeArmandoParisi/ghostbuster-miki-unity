using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private Animator parentAnimator;
    private PlayerBase player;
    private float nextFindTime;
    private Coroutine attackCoroutine;

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
        Vector3 dir = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle);

        // Spawn bullet at this GameObject's position with the computed rotation.
        if (bulletPrefab != null || parentAnimator != null)
        {
            parentAnimator.SetBool("isAttacking", true);
            if (LevelState.Instance.BossDefeated)
            {
                if (attackCoroutine != null)
                {
                    StopCoroutine(stopAttackAnimation());
                }
            }
            else
            {
                Instantiate(bulletPrefab, transform.position, rot);
            }
            attackCoroutine = StartCoroutine(stopAttackAnimation());
        }
        else
        {
            return;
        }

        nextFindTime = Time.time + shootInterval;
    }

    private IEnumerator stopAttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        parentAnimator.SetBool("isAttacking", false);
    }
}
