using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField, Range(2, 3)] private float speed;
    [SerializeField] private float findRetryInterval = 1f;
    [SerializeField] bool isBoss = false;
    private PlayerBase player;
    private Rigidbody2D rb;
    private float nextFindTime;

    void Start()
    {
        player = GameObjectUtils.FindPlayer();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isBoss && LevelState.Instance.BossDefeated)
        {
            return;
        }

        if (player == null)
        {
            if (Time.time >= nextFindTime)
            {
                player = GameObjectUtils.FindPlayer();
                nextFindTime = Time.time + findRetryInterval;
            }
            return;
        }

        Vector3 target = player.transform.position;

        Vector3 dir = (target - transform.position).normalized;
        if (Mathf.Abs(dir.x) > 0.001f)
        {
            transform.localScale = new Vector3(Mathf.Sign(dir.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // This is for the physics to work correctly, had a bug where the Enemy would fly away and never return
    void FixedUpdate()
    {
        if (isBoss && LevelState.Instance.BossDefeated)
        {
            return;
        }

        if (player == null)
        {
            return;
        }

        Vector2 pos = rb.position;
        Vector2 target = player.transform.position;
        rb.MovePosition(Vector2.MoveTowards(pos, target, speed * Time.fixedDeltaTime));
    }
}