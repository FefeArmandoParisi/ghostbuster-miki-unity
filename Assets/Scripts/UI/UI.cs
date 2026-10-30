using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainOverlay;
    [SerializeField] private GameObject gameOverOverlay;
    [SerializeField] private GameObject levelCompleteText;
    private PlayerBase player;
    private bool hasExited = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBase>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tryAgainOverlay != null)
        {
            tryAgainOverlay.SetActive(false);
        }

        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(false);
        }
    }

    // Update is called once per frame
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

        if (gameOverOverlay == null)
        {
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

            PauseGame();
            int remainingCredits = player.CheckRemainingCredits();
            if (remainingCredits > 0)
            {
                LevelState.Instance.SetInputLocked(true);
                tryAgainOverlay.SetActive(true);
            }
            else
            {
                gameOverOverlay.SetActive(true);
            }
        }

        if (LevelState.Instance.BossDefeated)
        {
            levelCompleteText.SetActive(true);
            StartCoroutine(LevelCompleteAnimation());
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

    void GameOverHide()
    {
        ResumeGame();
        gameOverOverlay.SetActive(false);
    }

    void ReturnToTitle()
    {
        hasExited = true;
        ResumeGame();
        SceneManager.LoadScene("TitleMenu"); //TODO: No hardcoded values
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

    public void RestartGame()
    {
        hasExited = true;
        GameOverHide();
        LevelState.Instance.SetInputLocked(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        hasExited = true;
        ResumeGame();
        SceneManager.LoadScene("TitleMenu"); //TODO: No hardcoded values
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
