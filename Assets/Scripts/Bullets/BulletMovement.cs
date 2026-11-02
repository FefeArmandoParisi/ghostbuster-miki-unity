using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private bool isBossBullet = false;
    [SerializeField] private float speed;

    private void Start()
    {
        Destroy(gameObject, 3); // gameObject is the object containing this script!
    }

    private void Update()
    {
        if (isBossBullet && LevelState.Instance.BossDefeated)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
