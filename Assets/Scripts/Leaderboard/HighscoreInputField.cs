using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreInputField : MonoBehaviour
{
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
        highscoreTable.UpdateHighscores();
        Destroy(gameObject);
    }

    void AddHighscore()
    {
        highscoreTable.highscoreEntryList.Add(new HighscoreTable.HighscoreEntry { name = _name, score = CollectableUI.collected});
        CollectableUI.collected = 0;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MountainPath");
    }
}
