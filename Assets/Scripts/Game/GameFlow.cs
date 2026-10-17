using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainOverlay;
    [SerializeField] private GameObject gameOverOverlay;
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
                tryAgainOverlay.SetActive(true);
            }
            else
            {
                gameOverOverlay.SetActive(true);
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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        hasExited = true;
        ResumeGame();
        SceneManager.LoadScene("TitleMenu"); //TODO: No hardcoded values
    }
}
