using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource laserSound;
    
    public static GameMusic instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            laserSound.Play();
        }
    }
}
