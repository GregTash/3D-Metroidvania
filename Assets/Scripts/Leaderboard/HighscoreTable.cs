using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class HighscoreTable : MonoBehaviour
{
    Transform _entryContainer;
    Transform _entryTemplate;
    List<Transform> _leaderboardSingleTransformList;

    private void Awake()
    {
        _entryContainer = transform.Find("HighscoreEntryContainer");
        _entryTemplate = _entryContainer.Find("HighscoreEntryTemplate");

        _entryTemplate.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //UpdateHighscores();
    }

    public void UpdateHighscores(Leaderboard leaderboard)
    {
        _leaderboardSingleTransformList = new List<Transform>();

        //Sort highscores.
        for (int i = 0; i < leaderboard.leaderboardSingleList.Count; i++)
        {
            for (int j = i + 1; j < leaderboard.leaderboardSingleList.Count; j++)
            {
                if (leaderboard.leaderboardSingleList[j].score > leaderboard.leaderboardSingleList[i].score)
                {
                    //Swap
                    LeaderboardSingle tmp = leaderboard.leaderboardSingleList[i];
                    leaderboard.leaderboardSingleList[i] = leaderboard.leaderboardSingleList[j];
                    leaderboard.leaderboardSingleList[j] = tmp;
                }
            }
        }

        //Refresh transforms.
        _leaderboardSingleTransformList.Clear();

        for (int i = _entryContainer.childCount - 1; i > 1; i--)
        {
            if(_entryContainer.GetChild(i).transform != _entryTemplate)
            {
                Destroy(_entryContainer.GetChild(i).gameObject);
            }
        }

        foreach (LeaderboardSingle leaderboardSingle in leaderboard.leaderboardSingleList)
        {
            CreateHighscoreEntryTransform(leaderboardSingle);
        }
    }

    void CreateHighscoreEntryTransform(LeaderboardSingle leaderboardSingle)
    {
        float templateHeight = 22f;

        Transform entryTransform = Instantiate(_entryTemplate, _entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * _leaderboardSingleTransformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = _leaderboardSingleTransformList.Count + 1;
        entryTransform.Find("PosText").GetComponent<TMP_Text>().text = rank.ToString();

        entryTransform.Find("NameText").GetComponent<TMP_Text>().text = leaderboardSingle.name;

        entryTransform.Find("ScoreText").GetComponent<TMP_Text>().text = leaderboardSingle.score.ToString();

        _leaderboardSingleTransformList.Add(entryTransform);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MountainPath");
    }
}