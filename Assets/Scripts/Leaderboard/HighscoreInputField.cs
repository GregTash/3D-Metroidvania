using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class HighscoreInputField : MonoBehaviour
{
    Leaderboard leaderboard;
    [SerializeField] HighscoreTable highscoreTable;
    [SerializeField] TMP_InputField inputField;
    string _name;

    private void Update()
    {
        _name = inputField.text;
    }

    public void OnButtonPress()
    {
        AddHighscore();
        Destroy(gameObject);
    }

    void AddHighscore()
    {
        WebRequests.Get
        ("https://nukileaderboard-gregtash.azurewebsites.net/api/GetLeaderboard?code=IrckXTSEqtKH-6O44fwvEIhAIxxGvH8Dr4oZUU0s8qAuAzFuREr-xA==",
            (string error) =>
            {
                Debug.Log("Error: " + error);
            },
            (string response) =>
            {
                Debug.Log("Response: " + response);

                Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
                //leaderboard.leaderboardSingleList.Add(new LeaderboardSingle { name = _name, score = CollectableUI.collected });
                highscoreTable.UpdateHighscores(leaderboard);
            }
        );

        CollectableUI.collected = 0;
    }
}
