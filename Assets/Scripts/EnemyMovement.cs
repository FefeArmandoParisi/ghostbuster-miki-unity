using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // horizontal speed (units per second). Positive moves right, negative moves left.
    public float speed = 1f;

    // vertical amplitude in Unity units
    public float verticalAmplitude = 1f;

    // vertical movement speed (units per second)
    public float verticalSpeed = 1f;

    // optional camera reference; if null, Camera.main will be used
    public Camera cam;

    private float startY;
    private bool movingUp = true;
    private float halfWidth = 0f;

    void Start()
    {
        startY = transform.position.y;
        cam = cam ? cam : Camera.main;

        // Get half width from any Renderer (SpriteRenderer, MeshRenderer, etc.)
        var r = GetComponent<Renderer>();
        if (r != null)
            halfWidth = r.bounds.extents.x;
    }

    void Update()
    {
        if (cam == null)
            return;

        // Horizontal movement (wrap when crossing camera edges)
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        // compute z distance for ViewportToWorldPoint
        float z = Mathf.Abs(cam.transform.position.z - transform.position.z);

        float leftWorld = cam.ViewportToWorldPoint(new Vector3(0f, 0f, z)).x - halfWidth;
        float rightWorld = cam.ViewportToWorldPoint(new Vector3(1f, 0f, z)).x + halfWidth;

        // If passed right edge -> wrap to left; if passed left edge -> wrap to right
        if (pos.x > rightWorld)
            pos.x = leftWorld;
        else if (pos.x < leftWorld)
            pos.x = rightWorld;

        // Vertical: oscillate between startY + verticalAmplitude and startY - verticalAmplitude
        float targetY = movingUp ? startY + verticalAmplitude : startY - verticalAmplitude;
        float newY = Mathf.MoveTowards(pos.y, targetY, verticalSpeed * Time.deltaTime);
        pos.y = newY;

        if (Mathf.Approximately(newY, targetY))
            movingUp = !movingUp;

        transform.position = pos;
    }
}