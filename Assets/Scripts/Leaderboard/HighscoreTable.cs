using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighscoreTable : MonoBehaviour
{
    Transform _entryContainer;
    Transform _entryTemplate;
    List<HighscoreEntry> _highscoreEntryList;
    List<Transform> _highscoreEntryTransformList;

    private void Awake()
    {
        _entryContainer = transform.Find("HighscoreEntryContainer");
        _entryTemplate = _entryContainer.Find("HighscoreEntryTemplate");

        _entryTemplate.gameObject.SetActive(false);

        _highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ name = "Greg", time = 113.52f},
            new HighscoreEntry{ name = "Bob", time = 12.55f},
            new HighscoreEntry{ name = "Trevor", time = 1123.32f},
            new HighscoreEntry{ name = "Billy", time = 2567.12f},
            new HighscoreEntry{ name = "Chad", time = 876.43f}
        };

        for(int i = 0; i < _highscoreEntryList.Count; i++)
        {
            for(int j = i+1; j < _highscoreEntryList.Count; j++)
            {
                if(_highscoreEntryList[j].time < _highscoreEntryList[i].time)
                {
                    //Swap
                    HighscoreEntry tmp = _highscoreEntryList[i];
                    _highscoreEntryList[i] = _highscoreEntryList[j];
                    _highscoreEntryList[j] = tmp;
                }
            }
        }

        _highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in _highscoreEntryList)
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

        entryTransform.Find("TimeText").GetComponent<TMP_Text>().text = highscoreEntry.time.ToString();

        transformList.Add(entryTransform);
    }

    class HighscoreEntry
    {
        public string name;
        public float time;
    }
}
