using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private AudioMixer audioSfxMixer;
    [SerializeField]
    private Slider volumeSfxSlider;

    void Start()
    {
        Time.timeScale = 1f;
        SetMusicVolume();
        SetSfxVolume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void SetMusicVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }

    public void SetSfxVolume()
    {
        float volume = volumeSfxSlider.value;
        audioSfxMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }

    void Stop()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void BackToMenu()
    {
        Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
