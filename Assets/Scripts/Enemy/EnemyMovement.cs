using UnityEngine;

public class EnemyOscilate : MonoBehaviour
{
    public float verticalAmplitude = 1f;

    public float verticalSpeed = 1f;

    public float speed = 1f;

    [SerializeField] private AnimationCurve verticalEase = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private float startY;
    private float oscillation01;

    private void OnEnable()
    {
        // Important for spawning/pooling: capture spawn Y each time this enemy is enabled
        startY = transform.position.y;
        oscillation01 = 0f;
    }

    void Update()
    {
        if (verticalAmplitude <= 0f || verticalSpeed <= 0f)
        {
            // still move forward even if vertical oscillation is disabled
            transform.position += Vector3.right * (speed * Time.deltaTime);
            return;
        }

        Vector3 pos = transform.position;

        // Forward movement
        pos += Vector3.right * (speed * Time.deltaTime);

        // Vertical oscillation with easing at top/bottom limits
        float fullRange = verticalAmplitude * 2f;
        oscillation01 += (verticalSpeed / fullRange) * Time.deltaTime;

        float t = Mathf.PingPong(oscillation01, 1f);     // 0..1..0
        float easedT = verticalEase.Evaluate(t);         // ease at both ends
        pos.y = Mathf.Lerp(startY - verticalAmplitude, startY + verticalAmplitude, easedT);

        transform.position = pos;
    }
}