using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuUI : MonoBehaviour
{
    public void HandleStartClick()
    {
        SceneManager.LoadScene(GameConstants.HowToPlay);
    }

    public void HandleCreditsClick()
    {
        SceneManager.LoadScene(GameConstants.ThankYouForPlaying);
    }

    public void HandleQuitClick()
    {
        Application.Quit();
    }
}
