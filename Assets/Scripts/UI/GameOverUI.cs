using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(GameConstants.SampleLevel);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(GameConstants.TitleMenu);
    }
}