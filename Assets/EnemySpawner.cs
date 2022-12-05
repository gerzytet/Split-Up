using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spots;
    public List<GameObject> enemies;
    public float difficulty = 1f;

    public double chance;
    //https://answers.unity.com/questions/421968/normal-distribution-random.html
    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;
 
        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);
 
        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
 
        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }

    GameObject chooseEnemy()
    {
        int index = Mathf.RoundToInt(Mathf.Max(Mathf.Min(RandomGaussian(difficulty - 1, difficulty + 1), 4), 1));
        return enemies[index - 1];
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0.0f, 1.0f) < chance)
        {
            Instantiate(chooseEnemy(), spots[Random.Range(0, spots.Count)].transform.position, Quaternion.identity);
        }
    }
}
