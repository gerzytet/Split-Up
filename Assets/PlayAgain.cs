using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayAgain : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        Scoreboard.score = 0;
    }
}
