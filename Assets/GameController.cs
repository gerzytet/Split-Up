using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> spots;
    public static GameController instance;
    public List<Sprite> slimes;
    public GameObject slime;
    public GameObject firstLaser;
    public GameObject laser;
    public List<Sprite> lasers;

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
