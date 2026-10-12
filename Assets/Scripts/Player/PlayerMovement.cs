using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float speedVar = speed * 1;

        if (Input.GetButton("Fire3"))
        {
            speedVar = speed * 1.5f;
        }

        transform.Translate(speedVar * Time.deltaTime * x, speedVar * Time.deltaTime * y, 0);

    }
}
