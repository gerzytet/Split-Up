using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int strength;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
    }
}
