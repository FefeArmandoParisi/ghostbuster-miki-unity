using System.Collections;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    private const float timeUntilRemoval = 0.5f;
    private void Start()
    {
        StartCoroutine(DestroyParticle());
    }

    private IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(timeUntilRemoval);

        Destroy(gameObject);
    }
}