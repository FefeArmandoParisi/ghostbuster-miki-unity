using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float fireInterval = 0.2f;
    private float nextFireTime = 0f;
    private Camera mainCam;
    private Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireInterval;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
