using UnityEngine;
using static GameConstants;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int health = 100; // TODO: Change this, should not be exposed. It's ok now for debug means.
    private PlayerStatus status = PlayerStatus.Default;

    public int CheckHealth()
    {
        return health;
    }

    public PlayerStatus CheckStatus()
    {
        return status;
    }

    public void SetStatus(PlayerStatus newStatus)
    {
        status = newStatus;
    }

    public void SetDefaultStatus()
    {
        status = PlayerStatus.Default;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            SetStatus(PlayerStatus.Dead);
        }
        else
        {
            SetStatus(PlayerStatus.Hurt);
        }
    }

    public void Recover(int recoverAmount)
    {
        health += recoverAmount;
    }
}