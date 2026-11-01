using UnityEngine;
using UnityEngine.SceneManagement;

public class ThankYouUI : MonoBehaviour
{
    public void SocialMediaIGClick()
    {
        Application.OpenURL(GameConstants.SocialMediaIGUrl);
    }

    public void SocialMediaXClick()
    {
        Application.OpenURL(GameConstants.SocialMediaXUrl);
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene(GameConstants.TitleMenu);
    }
}
