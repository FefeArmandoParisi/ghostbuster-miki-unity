using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void HandleDebugClick()
    {
        SceneManager.LoadScene("DebugScene"); //TODO: No hardcoded values
    }

    public void HandleQuitClick()
    {
        Application.Quit();
    }
}
