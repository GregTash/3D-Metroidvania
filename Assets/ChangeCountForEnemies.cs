using UnityEngine;
using TMPro;

public class ChangeCountForEnemies : MonoBehaviour
{
    int maxEnemies;
    [SerializeField] TMP_Text countText;

    private void Start()
    {
        maxEnemies = transform.childCount;
    }

    void Update()
    {
        countText.text = transform.childCount + "/" + maxEnemies;
    }
}
