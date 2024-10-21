using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void SetFullscreenMode()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Debug.Log("Fullscreen");
    }
    public void SetWindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
        Debug.Log("Windowed");
    }
}
