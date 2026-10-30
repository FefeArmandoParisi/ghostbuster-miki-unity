using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static GameConstants;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int maxHealth; // Max health is set by the value passed to this field
    [SerializeField] private float hurtDurationSeconds; // The Hurt Status duration is set by this field
    [SerializeField] private int maxCredits; // Max credit number is set by this field
    private Coroutine hurtResetCoroutine;
    private Coroutine flashCoroutine;
    private PlayerStatus status = PlayerStatus.Default;
    private int powerUpLevel = 1;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashingRed;
    private int currentHealth;
    private int currentCredits;

    public void Start()
    {
        ResetPlayer();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void Update()
    {
        ApplyVisualState();
    }

    private void ApplyVisualState()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        Color color = originalColor;

        if (status == PlayerStatus.Hurt)
        {
            color.a = 0.5f;
        }

        if (isFlashingRed)
        {
            color.r = 1f;
            color.g = 0f;
            color.b = 0f;
        }

        spriteRenderer.color = color;
    }

    public int CheckHealth()
    {
        return currentHealth;
    }

    public int CheckMaxHealth()
    {
        return maxHealth;
    }

    public PlayerStatus CheckStatus()
    {
        return status;
    }

    public int CheckPowerLevel()
    {
        return powerUpLevel;
    }

    public int CheckRemainingCredits()
    {
        return currentCredits;
    }

    public void SetStatus(PlayerStatus newStatus)
    {
        status = newStatus;
    }

    public void SetDefaultStatus()
    {
        status = PlayerStatus.Default;
    }

    public void SubstractCredit()
    {
        currentCredits--;
    }

    public void PowerUp()
    {
        if (powerUpLevel == 3) { return; }
        powerUpLevel++;
    }

    public void PowerDown()
    {
        if (powerUpLevel == 1) { return; }
        powerUpLevel--;
    }

    void HurtStatus()
    {
        SetStatus(PlayerStatus.Hurt);

        if (hurtResetCoroutine != null)
        {
            StopCoroutine(hurtResetCoroutine);
        }

        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        hurtResetCoroutine = StartCoroutine(ResetHurtStatusAfterDelay());
        flashCoroutine = StartCoroutine(FlashRedForFrames(20));
    }

    public void Damage(int damageAmount)
    {
        if (status == PlayerStatus.Hurt)
        {
            return;
        }

        // Had a bug where health could be -1 and it broke the health UI, 
        // so this max only allows the health to go so far as 0
        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);

        if (currentHealth == 0)
        {
            SetStatus(PlayerStatus.Dead);
            return;
        }

        HurtStatus();
    }

    // Might be left unused, I haven't added a recovery Item yet
    public void Recover(int recoverAmount)
    {
        currentHealth = Mathf.Min(currentHealth + recoverAmount, maxHealth);
    }

    public void ResetPlayer()
    {
        currentHealth = maxHealth;
        status = PlayerStatus.Default;
        powerUpLevel = 1;
        if (currentCredits > 0)
        {
            currentCredits--;
            HurtStatus();
        }
        else
        {
            currentCredits = maxCredits;
        }
    }

    private IEnumerator ResetHurtStatusAfterDelay()
    {
        yield return new WaitForSeconds(hurtDurationSeconds); // This will make a 'timer' for 'hurtDurationSeconds' until it goes to the next line.

        if (status == PlayerStatus.Hurt)
        {
            SetDefaultStatus();
        }

        ApplyVisualState();
        hurtResetCoroutine = null;
    }

    private IEnumerator FlashRedForFrames(int frames)
    {
        isFlashingRed = true;
        ApplyVisualState();

        for (int i = 0; i < frames; i++) // This will make a 'timer' for 'frames' until it goes to the next line.
        {
            yield return null;
        }

        isFlashingRed = false;
        ApplyVisualState();
        flashCoroutine = null;
    }
}