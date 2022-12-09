using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static int score = 0;

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
}
