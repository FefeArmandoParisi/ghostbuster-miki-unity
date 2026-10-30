using UnityEngine;

public class HealthUnit : MonoBehaviour
{
    private bool filled = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SubstractHeart()
    {
        SetFilled(false);
    }

    public void RestoreHeart()
    {
        SetFilled(true);
    }

    private void SetFilled(bool value)
    {
        filled = value;
        animator.SetBool(GameConstants.HeartFilled, filled);
    }
}