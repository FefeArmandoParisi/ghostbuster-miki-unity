using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [Header("Chase")]
    [SerializeField, Range(0f, 10f)]
    private float speed = 3f; // configurable in the Inspector as a slider
    [SerializeField]
    private float stopDistance = 0f;

    [Tooltip("How often (seconds) to retry finding the player if not present at Start.")]
    [SerializeField]
    private float findRetryInterval = 1f;

    private Transform player;
    private float nextFindTime;

    void Start()
    {
        player = GameObjectUtils.FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            if (Time.time >= nextFindTime)
            {
                player = GameObjectUtils.FindPlayer();
                nextFindTime = Time.time + findRetryInterval;
            }
            return;
        }

        Vector3 pos = transform.position;
        Vector3 target = player.position;
        float dist = Vector3.Distance(pos, target);

        if (dist > stopDistance)
        {
            Vector3 next = Vector3.MoveTowards(pos, target, speed * Time.deltaTime);
            transform.position = next;

            // Face target for 2D sprites
            Vector3 dir = (target - pos).normalized;
            if (Mathf.Abs(dir.x) > 0.001f)
                transform.localScale = new Vector3(Mathf.Sign(dir.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}