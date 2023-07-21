using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HighscoreTable : MonoBehaviour
{
    Transform _entryContainer;
    Transform _entryTemplate;
    public static List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
    List<Transform> _highscoreEntryTransformList;

    private void Awake()
    {
        _entryContainer = transform.Find("HighscoreEntryContainer");
        _entryTemplate = _entryContainer.Find("HighscoreEntryTemplate");

        _entryTemplate.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //UpdateHighscores();
    }

    public void UpdateHighscores()
    {
        _highscoreEntryTransformList = new List<Transform>();

        //Sort highscores.
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        //Refresh transforms.
        _highscoreEntryTransformList.Clear();

        for (int i = _entryContainer.childCount - 1; i > 1; i--)
        {
            if(_entryContainer.GetChild(i).transform != _entryTemplate)
            {
                Destroy(_entryContainer.GetChild(i).gameObject);
            }
        }

        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, _entryContainer, _highscoreEntryTransformList);
        }
    }

    void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 22f;

        Transform entryTransform = Instantiate(_entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("PosText").GetComponent<TMP_Text>().text = rank.ToString();

        entryTransform.Find("NameText").GetComponent<TMP_Text>().text = highscoreEntry.name;

        entryTransform.Find("ScoreText").GetComponent<TMP_Text>().text = highscoreEntry.score.ToString();

        transformList.Add(entryTransform);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MountainPath");
    }

    public class HighscoreEntry
    {
        public string name;
        public int score;
    }
}
