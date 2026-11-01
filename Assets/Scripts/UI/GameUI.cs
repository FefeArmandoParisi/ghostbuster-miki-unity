using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainOverlay;
    [SerializeField] private GameObject levelCompleteText;
    [SerializeField] private GameObject bossHealthDisplay;
    private PlayerBase player;
    private bool hasExited = false;

    void Start()
    {
        player = GameObjectUtils.FindPlayer();

        if (tryAgainOverlay != null)
        {
            tryAgainOverlay.SetActive(false);
        }

        if (bossHealthDisplay != null)
        {
            bossHealthDisplay.SetActive(false);
        }
    }

    void Update()
    {

        if (player == null)
        {
            return;
        }

        if (tryAgainOverlay == null)
        {
            return;
        }

        if (LevelState.Instance.BossFight)
        {
            bossHealthDisplay.SetActive(true);
        }

        if (LevelState.Instance.BossDefeated)
        {
            levelCompleteText.SetActive(true);
            StartCoroutine(LevelCompleteAnimation());
            return;
        }

        bool isDead = player.CheckStatus() == GameConstants.PlayerStatus.Dead;

        if (isDead)
        {
            if (hasExited)
            {
                ResumeGame();
                return;
            }

            int remainingCredits = player.CheckRemainingCredits();
            if (remainingCredits > 0)
            {
                PauseGame();
                LevelState.Instance.SetInputLocked(true);
                tryAgainOverlay.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(GameConstants.GameOver);
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void TryAgainHide()
    {
        ResumeGame();
        tryAgainOverlay.SetActive(false);
    }

    void ReturnToTitle()
    {
        hasExited = true;
        ResumeGame();
        SceneManager.LoadScene(GameConstants.TitleMenu);
    }

    public void TryAgainAccept()
    {
        LevelState.Instance.SetInputLocked(false);
        player.ResetPlayer();
        TryAgainHide();
    }

    public void TryAgainDecline()
    {
        ReturnToTitle();
    }

    public void QuitGame()
    {
        hasExited = true;
        ResumeGame();
        SceneManager.LoadScene(GameConstants.TitleMenu);
    }

    private IEnumerator LevelCompleteAnimation()
    {
        RectTransform textRect = levelCompleteText.GetComponent<RectTransform>();
        RectTransform canvasRect = textRect.parent as RectTransform;

        Vector2 start = new Vector2(0f, canvasRect.rect.height / 2f + textRect.rect.height / 2f);
        Vector2 end = new Vector2(0f, 100);

        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            textRect.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        textRect.anchoredPosition = end;
    }
}
