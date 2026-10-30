using UnityEngine;

public class BossWrapper : MonoBehaviour
{
    [SerializeField] private GameObject bossObject;
    private void Update()
    {
        bossObject.SetActive(LevelState.Instance.BossFight);
    }
}