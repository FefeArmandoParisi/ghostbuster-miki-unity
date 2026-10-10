using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void HandleDebugClick()
    {
        SceneManager.LoadScene("DebugScene");
    }

    public void HandleQuitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
}
