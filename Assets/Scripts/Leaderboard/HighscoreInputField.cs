using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.Collections;

public class HighscoreInputField : MonoBehaviour
{
    Leaderboard leaderboard;
    [SerializeField] HighscoreTable highscoreTable;
    [SerializeField] TMP_InputField inputField;
    string _name;
    [SerializeField] int collectablesCollected;

    private void Update()
    {
        _name = inputField.text;
    }

    public void OnButtonPress()
    {
        AddHighscore();
        Destroy(gameObject);
    }

    public delegate void OnLeaderboardSubmission();
    public static event OnLeaderboardSubmission onLeaderboardSubmissionEvent;

    private void OnEnable()
    {
        onLeaderboardSubmissionEvent += GetUpdatedScores;
    }

    void GetUpdatedScores()
    {
        WebRequests.Get
        ("https://nukileaderboard-tomgraham.azurewebsites.net/api/GetLeaderboard?code=tBNMgEfU8VWjvT0RB2cUvKrxHsgMzjJgx1jmbfdfj60mAzFuSxIfeg==",
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
    }

    void AddHighscore()
    {
        //onLeaderboardSubmissionEvent?.Invoke();

        LeaderboardSingle leaderboardSingle = new LeaderboardSingle
        {
            name = inputField.text,
            score = collectablesCollected,
        };

        WebRequests.PushAndReceive("https://nukileaderboard-tomgraham.azurewebsites.net/api/AddScore?code=3Aq0aZZTIypBDw7MT_W4lA4Gg-nhv9UYVG57FBTuGrNNAzFuPkIJmQ==", "https://nukileaderboard-tomgraham.azurewebsites.net/api/GetLeaderboard?code=tBNMgEfU8VWjvT0RB2cUvKrxHsgMzjJgx1jmbfdfj60mAzFuSxIfeg==",
            JsonConvert.SerializeObject(leaderboardSingle),
            (string error) =>
            {
                Debug.Log("Error: " + error);
            },
            (string response) =>
            {
                Debug.Log("Response: " + response);
            },
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

        highscoreTable.UpdateHighscores(leaderboard);

        //WebRequests.PostJson("https://nukileaderboard-tomgraham.azurewebsites.net/api/AddScore?code=3Aq0aZZTIypBDw7MT_W4lA4Gg-nhv9UYVG57FBTuGrNNAzFuPkIJmQ==", 
        //    JsonConvert.SerializeObject(leaderboardSingle),
        //    (string error) =>
        //    {
        //        Debug.Log("Error: " + error);
        //     },
        //    (string response) =>
        //    {
        //        Debug.Log("Response: " + response);
        //    }
        //    );



        CollectableUI.collected = 0;


    }
}
