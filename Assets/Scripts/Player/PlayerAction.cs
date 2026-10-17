using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float fireInterval = 0.2f;
    private float nextFireTime = 0f;
    private float bulletOffset = 20f;
    private Camera mainCam;
    private Vector3 mousePos;
    private PlayerBase player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerBase>();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireInterval;
            int powerLevel = player.CheckPowerLevel();

            switch (powerLevel)
            {
                case 2:
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, -bulletOffset));
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, bulletOffset));
                    break;
                case 3:
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, -bulletOffset));
                    Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, bulletOffset));
                    Instantiate(bullet, transform.position, transform.rotation);
                    break;
                default:
                    Instantiate(bullet, transform.position, transform.rotation);

                    break;
            }
        }
    }
}
