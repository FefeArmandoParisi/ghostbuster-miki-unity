using System.Collections;
using UnityEngine;

public class BulletEmit : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float interval = 60f;
    public bool spawnImmediately = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        if (spawnImmediately) EmitBullets();

        while (true)
        {
            yield return new WaitForSeconds(interval); // use WaitForSecondsRealtime(interval) if you need real-time unaffected by timeScale
            EmitBullets();
        }

    }

    void EmitBullets()
    {
        Debug.Log("reaches here");
        // forward bullet
        Instantiate(bullet, transform.position, transform.rotation);
        Quaternion rightRotation = transform.rotation * Quaternion.Euler(0f, 0f, 90f);
        Instantiate(bullet, transform.position, rightRotation);
        // calculate opposite rotation (180 degrees around Z) and spawn second bullet
        Quaternion oppositeRotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        Instantiate(bullet, transform.position, oppositeRotation);
        Quaternion leftRotation = transform.rotation * Quaternion.Euler(0f, 0f, 270f);
        Instantiate(bullet, transform.position, leftRotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1f);
    }
}
