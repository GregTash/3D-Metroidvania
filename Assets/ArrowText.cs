using UnityEngine;
using TMPro;

public class ArrowText : MonoBehaviour
{
    [SerializeField] BowController bowController;
    TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _text.text = bowController.arrowsLeft.ToString();
    }
}
