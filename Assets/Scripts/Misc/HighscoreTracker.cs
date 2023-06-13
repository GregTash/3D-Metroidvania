using TMPro;
using UnityEngine;

public class HighscoreTracker : MonoBehaviour
{
    [SerializeField] TMP_Text completionText;
    public bool trackTime = false;
    public static float completionTime = 0f;

    void Update()
    {
        if (!trackTime)
        {
            completionText.text = "Completion Time: " + completionTime.ToString("F2") + " Seconds";
            return;
        }
        completionTime += Time.deltaTime;
    }
}
