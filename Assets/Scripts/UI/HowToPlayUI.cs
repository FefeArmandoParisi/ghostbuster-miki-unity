using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(GameConstants.SampleLevel);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(GameConstants.TitleMenu);
    }
}