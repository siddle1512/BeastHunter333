using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private bool isFullscreen = false;

    void Start()
    {
        SetWindowedMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            ToggleFullscreen();
        }
    }

    public void ToggleFullscreen()
    {
        if (isFullscreen)
        {
            SetWindowedMode();
        }
        else
        {
            SetFullscreenMode();
        }
    }

    public void SetFullscreenMode()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        isFullscreen = true;
        Debug.Log("Fullscreen");
    }

    public void SetWindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
        isFullscreen = false;
        Debug.Log("Windowed");
    }
}
