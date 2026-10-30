using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] bool isBossBullet = false;
    public float speed;

    void Start()
    {
        Destroy(gameObject, 3); // gameObject is the object containing this script!
    }

    void Update()
    {
        if (isBossBullet && LevelState.Instance.BossDefeated)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
