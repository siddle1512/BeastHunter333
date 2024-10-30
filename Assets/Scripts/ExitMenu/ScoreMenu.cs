using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Threading.Tasks;

[System.Serializable]
public class ScoreEntry
{
    public string username;
    public int score;
}

[System.Serializable]
public class RankingResponse
{
    public List<ScoreEntry> top10;
    public int userRank;
}

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text Username1;
    [SerializeField] private TMP_Text Username2;
    [SerializeField] private TMP_Text Username3;
    [SerializeField] private TMP_Text Username4;
    [SerializeField] private TMP_Text CurrentUsername;
    [SerializeField] private TMP_Text Rank;

    [SerializeField] private TMP_Text Score1;
    [SerializeField] private TMP_Text Score2;
    [SerializeField] private TMP_Text Score3;
    [SerializeField] private TMP_Text Score4;
    [SerializeField] private TMP_Text CurrentScore;

    private const string apiUrl = "https://beasthunter333be-gvg3gvcqaehuexfu.canadacentral-01.azurewebsites.net/api/Ranking/add-score";

    public async void Start()
    {
        Username1.text = UsernameMenu.username;
        Score1.text = UsernameMenu.score.ToString();
        Debug.LogWarning("Request successful32132132!");
        await CallApiAndSetScores(UsernameMenu.username, UsernameMenu.score);
    }

    private async Task CallApiAndSetScores(string username, int score)
    {
        Debug.LogWarning("Request successful!111");
        // string jsonData = JsonUtility.ToJson(new { username, score });
        string jsonData = "{\"username\":\"" + username + "\",\"score\":" + score + "}";
        Debug.LogWarning(jsonData);
        using (UnityWebRequest request = UnityWebRequest.Post(apiUrl, jsonData, "application/json"))
        {
            request.SendWebRequest();
            Debug.LogWarning("Request result: " + request.result);
            await Task.Delay(4000);
            if (request.result == UnityWebRequest.Result.Success)
            {
                // Xử lý response
                Debug.LogWarning("Request successful!");
                RankingResponse response = JsonUtility.FromJson<RankingResponse>(request.downloadHandler.text);
                SetScores(response.top10);
                Rank.text = response.userRank.ToString();
                return; // Thoát coroutine nếu thành công
            }
            else
            {
                Debug.LogWarning($"Attempt failed: {request.error}");
            }

        }
    }

    private void SetScores(List<ScoreEntry> scores)
    {
        if (scores.Count >= 4)
        {
            Username1.text = scores[0].username;
            Username2.text = scores[1].username;
            Username3.text = scores[2].username;
            Username4.text = scores[3].username;
            CurrentUsername.text = UsernameMenu.username;

            Score1.text = scores[0].score.ToString();
            Score2.text = scores[1].score.ToString();
            Score3.text = scores[2].score.ToString();
            Score4.text = scores[3].score.ToString();
            CurrentScore.text = UsernameMenu.score.ToString();
            
        }
        else
        {
            Debug.LogWarning("Không đủ dữ liệu để hiển thị 4 người dùng.");
        }
    }
}
