using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemDiamondNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diamondNumber;
    [SerializeField] private TextMeshProUGUI gemNumber;

    private void Update()
    {
        diamondNumber.text = PlayerPrefs.GetInt("DiamondsCollected").ToString();
        gemNumber.text = PlayerPrefs.GetInt("GemsCollected").ToString();
    }
}
