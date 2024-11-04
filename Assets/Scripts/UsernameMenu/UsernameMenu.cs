using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Thêm namespace này

public class UsernameMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button submitButton; // Thêm reference đến button
    public static string username = "";
    public static int score = 0;

    void Start()
    {
        Debug.LogWarning("UsernameMenu started!"); // Log để kiểm tra
        // Kiểm tra nếu có button
        if (submitButton != null)
        {
            Debug.Log("Found button!"); // Log để kiểm tra
            submitButton.onClick.AddListener(() => {
                Debug.Log("Button clicked!"); // Log khi button được click
                UpdateUsername();
            });
        }
        else
        {
            Debug.LogError("Button is not assigned!"); // Log lỗi nếu không tìm thấy button
        }
    }

    private void UpdateUsername()
    {
        Debug.Log("Updating username..."); // Log để kiểm tra hàm được gọi
        if (usernameInputField != null && !string.IsNullOrEmpty(usernameInputField.text))
        {
            username = usernameInputField.text;
            Debug.Log("Username set to: " + username); // Log username
            LoadGameScene();
        }
        else
        {
            Debug.LogWarning("Username không được để trống!");
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnDestroy()
    {
        if(submitButton != null)
        {
            submitButton.onClick.RemoveAllListeners();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}