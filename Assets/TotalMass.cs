using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalMass : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int sum = 0;
        foreach (Slime slime in FindObjectsOfType<Slime>())
        {
            sum += slime.mass;
        }
        GetComponent<TextMeshProUGUI>().text = "Total Mass: " + sum;
    }
}
