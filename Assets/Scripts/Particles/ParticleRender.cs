using System.Collections;
using UnityEngine;

public class ParticleRender : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float particleSize = 4f;

    void Start()
    {
        StartCoroutine(SpawnParticles());
    }

    private IEnumerator SpawnParticles()
    {
        var wait = new WaitForSeconds(spawnInterval);

        while (true)
        {
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            particle.transform.localScale = Vector3.one * particleSize;
            yield return wait;
        }
    }
}